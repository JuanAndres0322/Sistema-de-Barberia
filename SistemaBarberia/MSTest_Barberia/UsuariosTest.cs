using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    [TestClass]
    public class UsuariosTest : BaseTest
    {
        private Usuarios? entidad;

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
            entidad = new Usuarios
            {
                ID_Rol = iConexion.Roles!.First().ID_Rol,
                ID_Barbero = iConexion.Barberos!.First().ID_Barbero,
                NombreUsuario = "usuario_prueba",
                HashContrasena = "hash_prueba***",
                UltimoAcceso = DateTime.Now
            };
            iConexion.Usuarios!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Usuario > 0;
        }

        private bool Modificar()
        {
            entidad!.NombreUsuario = "usuario_modificado";
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.Usuarios!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.Usuarios!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }
}
