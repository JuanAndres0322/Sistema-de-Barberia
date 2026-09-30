using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    [TestClass]
    public class RolesTest : BaseTest
    {
        private Roles? entidad;

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
            entidad = new Roles
            {
                Nombre = "Rol de prueba",
                Descripcion = "Descripcion de prueba",
                Activo = true
            };
            iConexion.Roles!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Rol > 0;
        }

        private bool Modificar()
        {
            entidad!.Nombre = "Rol modificado";
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.Roles!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.Roles!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }
}
