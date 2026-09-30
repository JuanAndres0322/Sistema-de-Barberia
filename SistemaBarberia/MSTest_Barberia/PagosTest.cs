using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    [TestClass]
    public class PagosTest : BaseTest
    {
        private Pagos? entidad;

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
            entidad = new Pagos
            {
                ID_Cita = iConexion.Citas!.First().ID_Cita,
                ID_Metodo = iConexion.MetodosPago!.First().ID_Metodo,
                MontoTotal = 20000m,
                FechaPago = DateTime.Now,
                ReferenciaVoucher = "VOU-PRUEBA"
            };
            iConexion.Pagos!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Pago > 0;
        }

        private bool Modificar()
        {
            entidad!.MontoTotal = 30000m;
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.Pagos!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.Pagos!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }
}
