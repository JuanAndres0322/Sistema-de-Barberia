using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Web_Barberia.Acceso
{
    public enum TipoCampo { Clave, Texto, TextoLargo, Secreto, Numero, Decimal, Fecha, FechaHora, Hora, Booleano, Relacion }

    public record Campo(PropertyInfo Propiedad, string Etiqueta, TipoCampo Tipo, bool Requerido, string? Relacion);

    public static class Esquema
    {
        private static readonly CultureInfo Cultura = CrearCultura();

        // Columnas DATE en SQL: se piden sin hora
        private static readonly HashSet<string> SoloFecha = new() { "FechaNacimiento", "FechaInicio", "FechaFin", "FechaAsignacion" };

        private static readonly Dictionary<string, string> Etiquetas = new()
        {
            ["CorreoElectronico"] = "Correo electrónico", ["FechaNacimiento"] = "Fecha de nacimiento",
            ["DuracionMinutos"] = "Duración (minutos)", ["Descripcion"] = "Descripción",
            ["ModuloApp"] = "Módulo", ["NombrePermiso"] = "Permiso", ["NombreEmpresa"] = "Empresa",
            ["NombreUsuario"] = "Usuario", ["HashContrasena"] = "Contraseña", ["UltimoAcceso"] = "Último acceso",
            ["CodigoBarras"] = "Código de barras", ["DiaSemana"] = "Día de la semana",
            ["ContactoPrincipal"] = "Contacto principal", ["ReferenciaVoucher"] = "Referencia del voucher",
            ["TipoDescuento"] = "Tipo de descuento", ["ValorDescuento"] = "Valor del descuento",
            ["NotasAdicionales"] = "Notas adicionales", ["FechaHora"] = "Fecha y hora", ["Telefono"] = "Teléfono",
            ["Direccion"] = "Dirección", ["Cedula"] = "Cédula", ["NIT"] = "NIT",
            ["ID_Metodo"] = "Método de pago", ["ID_Categoria"] = "Categoría",
        };

        private static CultureInfo CrearCultura()
        {
            try { return new CultureInfo("es-CO"); }
            catch (CultureNotFoundException) { return CultureInfo.InvariantCulture; }
        }

        // La llave primaria es la unica propiedad int (no nula) que empieza por ID_
        public static PropertyInfo Llave(Type tipo) =>
            tipo.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .First(p => p.PropertyType == typeof(int) && p.Name.StartsWith("ID_"));

        public static List<Campo> Campos(Type tipo)
        {
            var llave = Llave(tipo);
            var nulos = new NullabilityInfoContext();
            var campos = new List<Campo>();

            foreach (var p in tipo.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var baseTipo = Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType;
                if (!EsEscalar(baseTipo)) continue; // listas y objetos relacionados no son columnas

                string? relacion = null;
                TipoCampo tipoCampo;
                if (p.Name == llave.Name) tipoCampo = TipoCampo.Clave;
                else if (Catalogo.Relaciones.TryGetValue(p.Name, out relacion)) tipoCampo = TipoCampo.Relacion;
                else if (p.Name == "HashContrasena") tipoCampo = TipoCampo.Secreto;
                else if (p.Name is "Descripcion" or "NotasAdicionales") tipoCampo = TipoCampo.TextoLargo;
                else if (baseTipo == typeof(int)) tipoCampo = TipoCampo.Numero;
                else if (baseTipo == typeof(decimal)) tipoCampo = TipoCampo.Decimal;
                else if (baseTipo == typeof(bool)) tipoCampo = TipoCampo.Booleano;
                else if (baseTipo == typeof(DateTime)) tipoCampo = SoloFecha.Contains(p.Name) ? TipoCampo.Fecha : TipoCampo.FechaHora;
                else if (baseTipo == typeof(TimeSpan)) tipoCampo = TipoCampo.Hora;
                else tipoCampo = TipoCampo.Texto;

                var requerido = baseTipo == typeof(string)
                                && nulos.Create(p).WriteState == NullabilityState.NotNull;

                campos.Add(new Campo(p, EtiquetaDe(p.Name), tipoCampo, requerido, relacion));
            }
            return campos;
        }

        private static bool EsEscalar(Type t) =>
            t == typeof(string) || t == typeof(int) || t == typeof(decimal) ||
            t == typeof(bool) || t == typeof(DateTime) || t == typeof(TimeSpan);

        private static string EtiquetaDe(string nombre)
        {
            if (Etiquetas.TryGetValue(nombre, out var etiqueta)) return etiqueta;
            var limpio = nombre.StartsWith("ID_") ? nombre[3..] : nombre;
            var conEspacios = Regex.Replace(limpio, "(?<=[a-z])(?=[A-Z])", " ");
            return char.ToUpper(conEspacios[0]) + conEspacios[1..].ToLower();
        }

        // Como se ve un valor en la tabla
        public static string Formatear(Campo campo, object? valor)
        {
            if (valor == null) return "—";
            return campo.Tipo switch
            {
                TipoCampo.Secreto => "••••••",
                TipoCampo.Booleano => (bool)valor ? "Sí" : "No",
                TipoCampo.Fecha => ((DateTime)valor).ToString("dd/MM/yyyy", Cultura),
                TipoCampo.FechaHora => ((DateTime)valor).ToString("dd/MM/yyyy HH:mm", Cultura),
                TipoCampo.Hora => ((TimeSpan)valor).ToString(@"hh\:mm"),
                TipoCampo.Decimal => ((decimal)valor).ToString("N2", Cultura),
                _ => valor.ToString() ?? ""
            };
        }

        // Como se escribe un valor dentro de un <input>
        public static string Entrada(Campo campo, object? valor)
        {
            if (valor == null) return "";
            return campo.Tipo switch
            {
                TipoCampo.Secreto => "",
                TipoCampo.Booleano => (bool)valor ? "true" : "false",
                TipoCampo.Fecha => ((DateTime)valor).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                TipoCampo.FechaHora => ((DateTime)valor).ToString("yyyy-MM-dd'T'HH:mm", CultureInfo.InvariantCulture),
                TipoCampo.Hora => ((TimeSpan)valor).ToString(@"hh\:mm", CultureInfo.InvariantCulture),
                TipoCampo.Decimal => ((decimal)valor).ToString(CultureInfo.InvariantCulture),
                _ => Convert.ToString(valor, CultureInfo.InvariantCulture) ?? ""
            };
        }

        // Texto del formulario -> valor de la propiedad. Lanza FormatException si no se puede convertir.
        public static object? Convertir(Campo campo, string? texto)
        {
            var tipo = Nullable.GetUnderlyingType(campo.Propiedad.PropertyType) ?? campo.Propiedad.PropertyType;

            if (tipo == typeof(string))
            {
                var limpio = texto?.Trim();
                return string.IsNullOrEmpty(limpio) ? (campo.Requerido ? "" : null) : limpio;
            }
            if (string.IsNullOrWhiteSpace(texto)) return null;

            texto = texto.Trim();
            if (tipo == typeof(int)) return int.Parse(texto, NumberStyles.Integer, CultureInfo.InvariantCulture);
            if (tipo == typeof(decimal)) return decimal.Parse(texto.Replace(',', '.'), NumberStyles.Number, CultureInfo.InvariantCulture);
            if (tipo == typeof(bool)) return texto == "true";
            if (tipo == typeof(DateTime)) return DateTime.Parse(texto, CultureInfo.InvariantCulture);
            if (tipo == typeof(TimeSpan)) return TimeSpan.Parse(texto, CultureInfo.InvariantCulture);
            return texto;
        }

        // Nombre corto de un registro: sirve para los menus desplegables y para confirmar borrados
        public static string Rotulo(object entidad)
        {
            var tipo = entidad.GetType();
            var id = Llave(tipo).GetValue(entidad);

            foreach (var nombre in new[] { "Nombre", "NombreEmpresa", "NombrePermiso", "NombreUsuario" })
            {
                if (tipo.GetProperty(nombre)?.GetValue(entidad) is string texto && texto.Length > 0) return texto;
            }
            foreach (var nombre in new[] { "FechaHora", "FechaVenta" })
            {
                if (tipo.GetProperty(nombre)?.GetValue(entidad) is DateTime fecha)
                    return $"#{id} del {fecha.ToString("dd/MM/yyyy HH:mm", Cultura)}";
            }
            return $"#{id}";
        }
    }
}
