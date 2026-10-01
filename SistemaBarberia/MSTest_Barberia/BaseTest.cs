using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    public abstract class BaseTest
    {
        protected readonly IConexion iConexion;

        protected BaseTest()
        {
            iConexion = new Conexion
            {
                StringConexion = "Server=.\\SQLEXPRESS;Database=BD_Barberia;Trusted_Connection=True;TrustServerCertificate=True;"
            };
        }

        protected void Actualizar(object entidad)
        {
            iConexion.Entry(entidad).State = EntityState.Modified;
            iConexion.SaveChanges();
        }
    }
}
