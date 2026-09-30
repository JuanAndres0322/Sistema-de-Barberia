using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    [TestClass]
    public class VentaProductosTest : BaseTest
    {
        private VentaProductos? entidad;

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
            entidad = new VentaProductos
            {
                ID_Cliente = iConexion.Clientes!.First().ID_Cliente,
                ID_Barbero = iConexion.Barberos!.First().ID_Barbero,
                FechaVenta = DateTime.Now,
                TotalVenta = 10000m,
                EstadoVenta = "Pendiente"
            };
            iConexion.VentaProductos!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Venta > 0;
        }

        private bool Modificar()
        {
            entidad!.EstadoVenta = "Pagada";
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.VentaProductos!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.VentaProductos!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }
}
