using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Lib_Barberia.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    [TestClass]
    public class PermisosTest
    {
        private IConexion? iConexion;
        private Permisos? entidad;

        public PermisosTest()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = DatosGenerales.ObtenerStringConnection();
        }

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
            iConexion?.Permisos!.Add(entidad);
            iConexion?.SaveChanges();
            return entidad?.ID_Permiso > 0;
        }

        private bool Modificar()
        {
            entidad!.NombrePermiso = "Permiso modificado";
            var entry = this.iConexion!.Entry(this.entidad!);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        private bool Listar() => iConexion?.Permisos!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion?.Permisos!.Remove(entidad!);
            iConexion?.SaveChanges();
            return true;
        }
    }
}
