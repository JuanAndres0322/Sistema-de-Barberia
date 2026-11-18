using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Web_Barberia.Acceso;
using Web_Barberia.Models;

namespace Web_Barberia.Controllers
{
    // CRUD completo (Index, Crear, Editar, Borrar) para cualquier entidad.
    // Cada entidad solo declara su controlador: ver BarberosController.
    public abstract class CrudController<T> : Controller where T : class, new()
    {
        private readonly ApiClient _api;
        private readonly EntidadInfo _info;
        private readonly PropertyInfo _llave = Esquema.Llave(typeof(T));

        protected CrudController(ApiClient api, string ruta)
        {
            _api = api;
            _info = Catalogo.Buscar(ruta) ?? throw new InvalidOperationException($"La entidad '{ruta}' no está en el Catalogo.");
        }

        // ---------- Listar ----------
        public async Task<IActionResult> Index()
        {
            var campos = Esquema.Campos(typeof(T));
            var vm = new ListaVM { Info = _info, Campos = campos };
            try
            {
                var datos = await _api.ListarAsync<T>(_info.Ruta);
                var rotulos = await CargarRotulos(campos);
                foreach (var item in datos)
                {
                    vm.Filas.Add(new FilaVM
                    {
                        Id = IdDe(item),
                        Celdas = campos.Where(c => c.Tipo != TipoCampo.Clave)
                                       .Select(c => Celda(c, item, rotulos)).ToList()
                    });
                }
            }
            catch (ApiException ex) { vm.Error = ex.Message; }
            return View("Lista", vm);
        }

        // ---------- Crear ----------
        [HttpGet]
        public Task<IActionResult> Crear() => Formulario(false, 0, new Dictionary<string, string>(), null);

        [HttpPost]
        public async Task<IActionResult> Crear(IFormCollection form)
        {
            var (entidad, errores) = Construir(form, null);
            if (errores.Count == 0)
            {
                try
                {
                    await _api.GuardarAsync(_info.Ruta, entidad);
                    TempData["Ok"] = "El registro se guardó.";
                    return RedirectToAction(nameof(Index));
                }
                catch (ApiException ex) { errores.Add(ex.Message); }
            }
            return await Formulario(false, 0, ValoresDe(form), errores);
        }

        // ---------- Editar ----------
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            try
            {
                var actual = await Buscar(id);
                if (actual == null) return Volver("Ese registro ya no existe.");
                var valores = Esquema.Campos(typeof(T))
                    .ToDictionary(c => c.Propiedad.Name, c => Esquema.Entrada(c, c.Propiedad.GetValue(actual)));
                return await Formulario(true, id, valores, null);
            }
            catch (ApiException ex) { return Volver(ex.Message); }
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, IFormCollection form)
        {
            var errores = new List<string>();
            try
            {
                var actual = await Buscar(id);
                if (actual == null) return Volver("Ese registro ya no existe.");

                T entidad;
                (entidad, errores) = Construir(form, actual);
                if (errores.Count == 0)
                {
                    _llave.SetValue(entidad, id);
                    await _api.ModificarAsync(_info.Ruta, entidad);
                    TempData["Ok"] = "Los cambios se guardaron.";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (ApiException ex) { errores.Add(ex.Message); }
            return await Formulario(true, id, ValoresDe(form), errores);
        }

        // ---------- Borrar ----------
        [HttpGet]
        public async Task<IActionResult> Borrar(int id)
        {
            try
            {
                var actual = await Buscar(id);
                if (actual == null) return Volver("Ese registro ya no existe.");
                return View("Confirmar", new ConfirmarVM { Info = _info, Id = id, Rotulo = Esquema.Rotulo(actual) });
            }
            catch (ApiException ex) { return Volver(ex.Message); }
        }

        [HttpPost, ActionName("Borrar")]
        public async Task<IActionResult> ConfirmarBorrado(int id)
        {
            try
            {
                var actual = await Buscar(id);
                if (actual == null) return Volver("Ese registro ya no existe.");
                await _api.BorrarAsync(_info.Ruta, actual);
                TempData["Ok"] = "El registro se borró.";
                return RedirectToAction(nameof(Index));
            }
            catch (ApiException ex) { return Volver(ex.Message); }
        }

        // ---------- Apoyo ----------
        private IActionResult Volver(string error)
        {
            TempData["Error"] = error;
            return RedirectToAction(nameof(Index));
        }

        private int IdDe(object entidad) => (int)_llave.GetValue(entidad)!;

        // La API no tiene "buscar por id": se lista y se filtra aqui
        private async Task<T?> Buscar(int id) =>
            (await _api.ListarAsync<T>(_info.Ruta)).FirstOrDefault(e => IdDe(e) == id);

        private async Task<IActionResult> Formulario(bool editando, int id, Dictionary<string, string> valores, List<string>? errores)
        {
            var campos = Esquema.Campos(typeof(T));
            var vm = new FormularioVM
            {
                Info = _info, Campos = campos, Editando = editando, Id = id,
                Valores = valores, Errores = errores ?? new List<string>()
            };
            try { vm.Opciones = await CargarRotulos(campos); }
            catch (ApiException ex) { vm.Errores.Add(ex.Message); }
            return View("Formulario", vm);
        }

        private static Dictionary<string, string> ValoresDe(IFormCollection form) =>
            Esquema.Campos(typeof(T)).ToDictionary(c => c.Propiedad.Name, c => form[c.Propiedad.Name].ToString());

        // Arma la entidad a partir de lo que se escribio en el formulario
        private (T entidad, List<string> errores) Construir(IFormCollection form, T? existente)
        {
            var entidad = new T();
            var errores = new List<string>();

            foreach (var c in Esquema.Campos(typeof(T)))
            {
                if (c.Tipo == TipoCampo.Clave) continue;
                var texto = form[c.Propiedad.Name].ToString();

                if (c.Tipo == TipoCampo.Secreto)
                {
                    if (string.IsNullOrWhiteSpace(texto) && existente != null)
                    {
                        c.Propiedad.SetValue(entidad, c.Propiedad.GetValue(existente)); // vacío = conservar la actual
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(texto))
                    {
                        texto = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(texto)));
                    }
                }

                if (c.Requerido && string.IsNullOrWhiteSpace(texto))
                {
                    errores.Add($"{c.Etiqueta} es obligatorio.");
                    continue;
                }
                try { c.Propiedad.SetValue(entidad, Esquema.Convertir(c, texto)); }
                catch (Exception ex) when (ex is FormatException or OverflowException)
                {
                    errores.Add($"{c.Etiqueta} no tiene un formato válido.");
                }
            }
            return (entidad, errores);
        }

        // Para cada llave foranea, trae la lista de la otra entidad: id -> nombre
        private async Task<Dictionary<string, Dictionary<int, string>>> CargarRotulos(IEnumerable<Campo> campos)
        {
            var resultado = new Dictionary<string, Dictionary<int, string>>();
            foreach (var ruta in campos.Where(c => c.Tipo == TipoCampo.Relacion).Select(c => c.Relacion!).Distinct())
            {
                var destino = Catalogo.Buscar(ruta)!;
                var llave = Esquema.Llave(destino.Tipo);
                var nombres = new Dictionary<int, string>();
                foreach (var e in await _api.ListarAsync(destino.Tipo, ruta))
                {
                    nombres[(int)llave.GetValue(e)!] = Esquema.Rotulo(e!);
                }
                resultado[ruta] = nombres;
            }
            return resultado;
        }

        private static string Celda(Campo campo, object item, Dictionary<string, Dictionary<int, string>> rotulos)
        {
            var valor = campo.Propiedad.GetValue(item);
            if (campo.Tipo == TipoCampo.Relacion)
            {
                if (valor is not int id) return "—";
                return rotulos.TryGetValue(campo.Relacion!, out var nombres) && nombres.TryGetValue(id, out var nombre)
                    ? nombre : $"#{id}";
            }
            return Esquema.Formatear(campo, valor);
        }
    }
}
