using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    // Clase base: crea la conexion una sola vez para todas las pruebas.
    // Si separan las pruebas en archivos, cada archivo necesita esta clase (o dejarla en su propio archivo).
    public abstract class BaseTest
    {
        protected readonly IConexion iConexion;

        protected BaseTest()
        {
            iConexion = new Conexion
            {
                StringConexion = "Server=localhost;Database=BD_Barberia;Trusted_Connection=True;TrustServerCertificate=True;"
            };
        }

        protected void Actualizar(object entidad)
        {
            iConexion.Entry(entidad).State = EntityState.Modified;
            iConexion.SaveChanges();
        }
    }
}
