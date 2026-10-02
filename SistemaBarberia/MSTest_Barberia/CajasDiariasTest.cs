using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Lib_Barberia.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    [TestClass]
    public class CajasDiariasTest
    {
        private IConexion? iConexion;
        private CajasDiarias? entidad;

        public CajasDiariasTest()
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
            entidad = new CajasDiarias
            {
                ID_Sucursal = iConexion.Sucursales!.First().ID_Sucursal,
                FechaApertura = DateTime.Now,
                SaldoInicial = 100000m,
                SaldoFinal = 100000m,
                EstadoCaja = "Abierta"
            };
            iConexion.CajasDiarias!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Caja > 0;
        }

        private bool Modificar()
        {
            entidad!.EstadoCaja = "Cerrada";
            var entry = this.iConexion!.Entry(this.entidad!);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        private bool Listar() => iConexion.CajasDiarias!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion?.CajasDiarias!.Remove(entidad!);
            iConexion?.SaveChanges();
            return true;
        }
    }
}
