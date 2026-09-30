using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    [TestClass]
    public class CategoriasProductoTest : BaseTest
    {
        private CategoriasProducto? entidad;

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
            entidad = new CategoriasProducto
            {
                Nombre = "Categoria de prueba",
                Descripcion = "Descripcion de prueba",
                Activo = true
            };
            iConexion.CategoriasProducto!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Categoria > 0;
        }

        private bool Modificar()
        {
            entidad!.Nombre = "Categoria modificada";
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.CategoriasProducto!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.CategoriasProducto!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }
}
