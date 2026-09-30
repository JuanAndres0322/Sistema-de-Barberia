using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    [TestClass]
    public class BarberosTest : BaseTest
    {
        private Barberos? entidad;

        [TestMethod]
        public void Ejecutar()
        {
            Assert.IsTrue(Guardar());
            Assert.IsTrue(Modificar());
            Assert.IsTrue(Listar());
            Assert.IsTrue(Borrar());
        }

        private bool Guardar()
        {
            entidad = new Barberos
            {
                Cedula = "99999",
                Nombre = "Barbero de prueba",
                Telefono = "3000000000",
                Especialidad = "Prueba",
                Activo = true
            };
            iConexion.Barberos!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Barbero > 0;
        }

        private bool Modificar()
        {
            entidad!.Nombre = "Barbero modificado";
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.Barberos!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.Barberos!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }
}
