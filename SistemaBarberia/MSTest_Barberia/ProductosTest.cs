using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Lib_Barberia.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    [TestClass]
    public class ProductosTest
    {
        private IConexion? Iconexion;
        private Productos? entidad;

        public ProductosTest()
        {
            this.Iconexion = new Conexion();
            this.Iconexion.StringConexion = DatosGenerales.ObtenerStringConnection();
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
            entidad = new Productos
            {
                ID_Categoria = Iconexion?.CategoriasProducto!.First().ID_Categoria,
                ID_Proveedor = Iconexion?.Proveedores!.First().ID_Proveedor,
                Nombre = "Producto de prueba",
                CodigoBarras = "0000000000000",
                PrecioVenta = 10000m,
                StockActual = 10
            };
            Iconexion?.Productos!.Add(entidad);
            Iconexion?.SaveChanges();
            return entidad?.ID_Producto > 0;
        }

        private bool Modificar()
        {
            entidad!.Nombre = "Producto modificado";
            var entry = this.Iconexion!.Entry(this.entidad!);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.Iconexion!.SaveChanges();
            return true;
        }

        private bool Listar() => Iconexion?.Productos!.ToList().Count > 0;

        private bool Borrar()
        {
            Iconexion?.Productos!.Remove(entidad!);
            Iconexion?.SaveChanges();
            return true;
        }
    }
}
