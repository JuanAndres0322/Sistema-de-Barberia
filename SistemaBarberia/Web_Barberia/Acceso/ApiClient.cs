using System.Collections;
using System.Net.Http.Json;
using System.Text.Json;

namespace Web_Barberia.Acceso
{
    public class ApiException : Exception
    {
        public ApiException(string mensaje, Exception? interna = null) : base(mensaje, interna) { }
    }

    public class ApiClient
    {
        private static readonly JsonSerializerOptions Opciones = new(JsonSerializerDefaults.Web);
        private readonly HttpClient _http;

        public ApiClient(HttpClient http) => _http = http;

        public string Direccion => _http.BaseAddress?.ToString().TrimEnd('/') ?? "";

        public async Task<List<T>> ListarAsync<T>(string ruta)
        {
            var json = await EnviarAsync(HttpMethod.Get, $"{ruta}/Listar", null);
            return JsonSerializer.Deserialize<List<T>>(json, Opciones) ?? new List<T>();
        }

        public async Task<IList> ListarAsync(Type tipo, string ruta)
        {
            var json = await EnviarAsync(HttpMethod.Get, $"{ruta}/Listar", null);
            var tipoLista = typeof(List<>).MakeGenericType(tipo);
            return (IList)(JsonSerializer.Deserialize(json, tipoLista, Opciones) ?? Activator.CreateInstance(tipoLista)!);
        }

        public Task GuardarAsync<T>(string ruta, T entidad) where T : notnull
            => EnviarAsync(HttpMethod.Post, $"{ruta}/Guardar", entidad);

        public Task ModificarAsync<T>(string ruta, T entidad) where T : notnull
            => EnviarAsync(HttpMethod.Put, $"{ruta}/Modificar", entidad);

        public Task BorrarAsync<T>(string ruta, T entidad) where T : notnull
            => EnviarAsync(HttpMethod.Delete, $"{ruta}/Borrar", entidad);

        private async Task<string> EnviarAsync(HttpMethod metodo, string url, object? cuerpo)
        {
            try
            {
                using var peticion = new HttpRequestMessage(metodo, url);
                if (cuerpo != null)
                {
                    peticion.Content = JsonContent.Create(cuerpo, cuerpo.GetType(), options: Opciones);
                }

                using var respuesta = await _http.SendAsync(peticion);
                var texto = await respuesta.Content.ReadAsStringAsync();

                if (!respuesta.IsSuccessStatusCode)
                {
                    throw new ApiException(MensajeDeError((int)respuesta.StatusCode, metodo));
                }
                return texto;
            }
            catch (HttpRequestException ex)
            {
                throw new ApiException($"No se pudo conectar con la API en {Direccion}. Inicia el proyecto Servicios_Barberia y vuelve a intentar.", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new ApiException("La API tardó demasiado en responder. Revisa que esté corriendo y que la base de datos conecte.", ex);
            }
        }

        private static string MensajeDeError(int codigo, HttpMethod metodo) => codigo switch
        {
            400 => "La API rechazó los datos (400). Revisa que los campos obligatorios estén completos.",
            404 => "La API no encontró esa ruta (404). Revisa que la dirección de la API sea la correcta.",
            500 when metodo == HttpMethod.Delete => "No se pudo borrar (500). Es probable que otros registros dependan de este.",
            500 => "La API falló al guardar (500). Revisa la consola de Servicios_Barberia y la conexión a SQL Server.",
            _ => $"La API respondió con el código {codigo}."
        };
    }
}
