using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    [TestClass]
    public class PermisosTest : BaseTest
    {
        private Permisos? entidad;

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
            entidad = new Permisos
            {
                NombrePermiso = "Permiso de prueba",
                ModuloApp = "Pruebas",
                Descripcion = "Descripcion de prueba"
            };
            iConexion.Permisos!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Permiso > 0;
        }

        private bool Modificar()
        {
            entidad!.NombrePermiso = "Permiso modificado";
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.Permisos!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.Permisos!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }
}
