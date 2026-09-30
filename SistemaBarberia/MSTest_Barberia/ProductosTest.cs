using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    [TestClass]
    public class ProductosTest : BaseTest
    {
        private Productos? entidad;

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
            entidad = new Productos
            {
                ID_Categoria = iConexion.CategoriasProducto!.First().ID_Categoria,
                ID_Proveedor = iConexion.Proveedores!.First().ID_Proveedor,
                Nombre = "Producto de prueba",
                CodigoBarras = "0000000000000",
                PrecioVenta = 10000m,
                StockActual = 10
            };
            iConexion.Productos!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Producto > 0;
        }

        private bool Modificar()
        {
            entidad!.Nombre = "Producto modificado";
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.Productos!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.Productos!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }
}
