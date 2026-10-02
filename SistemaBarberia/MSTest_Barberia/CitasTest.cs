using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Lib_Barberia.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    [TestClass]
    public class CitasTest
    {
        private IConexion? iConexion;
        private Citas? entidad;

        public CitasTest()
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
            entidad = new Citas
            {
                ID_Cliente = iConexion?.Clientes!.First().ID_Cliente,
                ID_Barbero = iConexion?.Barberos!.First().ID_Barbero,
                FechaHora = DateTime.Now,
                Estado = "Pendiente",
                NotasAdicionales = "Prueba"
            };
            iConexion?.Citas!.Add(entidad);
            iConexion?.SaveChanges();
            return entidad?.ID_Cita > 0;
        }

        private bool Modificar()
        {
            entidad!.Estado = "Confirmada";
            var entry = this.iConexion!.Entry(this.entidad!);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        private bool Listar() => iConexion?.Citas!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion?.Citas!.Remove(entidad!);
            iConexion?.SaveChanges();
            return true;
        }
    }
}
