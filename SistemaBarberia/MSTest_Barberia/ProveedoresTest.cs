using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    [TestClass]
    public class ProveedoresTest : BaseTest
    {
        private Proveedores? entidad;

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
            entidad = new Proveedores
            {
                NIT = "999999999",
                NombreEmpresa = "Proveedor de prueba",
                ContactoPrincipal = "Contacto de prueba",
                Telefono = "3000000000",
                Email = "prueba@proveedor.com"
            };
            iConexion.Proveedores!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Proveedor > 0;
        }

        private bool Modificar()
        {
            entidad!.NombreEmpresa = "Proveedor modificado";
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.Proveedores!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.Proveedores!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }
}
