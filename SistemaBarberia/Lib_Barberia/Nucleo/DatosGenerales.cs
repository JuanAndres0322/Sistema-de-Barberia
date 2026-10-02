namespace Lib_Barberia.Nucleo
{
    public class DatosGenerales
    {
        public static string ObtenerStringConnection()
        {
            return "Server=.\\SQLEXPRESS;Database=BD_Barberia;Trusted_Connection=True;TrustServerCertificate=True;";
        }
    }
}