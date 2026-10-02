using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Lib_Barberia.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    [TestClass]
    public class VentaProductosTest
    {
        private IConexion iConexion;
        private VentaProductos? entidad;

        public VentaProductosTest()
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
            var entry = this.iConexion!.Entry(this.entidad!);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.iConexion!.SaveChanges();
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
