using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    [TestClass]
    public class DetalleVentaProductosTest : BaseTest
    {
        private DetalleVentaProductos? entidad;

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
            entidad = new DetalleVentaProductos
            {
                ID_Venta = iConexion.VentaProductos!.First().ID_Venta,
                ID_Producto = iConexion.Productos!.First().ID_Producto,
                Cantidad = 1,
                PrecioUnitario = 10000m,
                Subtotal = 10000m
            };
            iConexion.DetalleVentaProductos!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Detalle > 0;
        }

        private bool Modificar()
        {
            entidad!.Cantidad = 2;
            entidad.Subtotal = 20000m;
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.DetalleVentaProductos!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.DetalleVentaProductos!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }
}
