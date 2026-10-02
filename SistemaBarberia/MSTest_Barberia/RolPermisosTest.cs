using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Lib_Barberia.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    [TestClass]
    public class RolPermisosTest
    {
        private IConexion iConexion;
        private RolPermisos? entidad;

        public RolPermisosTest()
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
            entidad = new RolPermisos
            {
                ID_Rol = iConexion.Roles!.First().ID_Rol,
                ID_Permiso = iConexion.Permisos!.First().ID_Permiso,
                FechaAsignacion = DateTime.Now,
                Habilitado = true
            };
            iConexion.RolPermisos!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_RolPermiso > 0;
        }

        private bool Modificar()
        {
            entidad!.Habilitado = false;
            var entry = this.iConexion!.Entry(this.entidad!);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        private bool Listar() => iConexion.RolPermisos!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.RolPermisos!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }
}
