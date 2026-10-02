using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Lib_Barberia.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    [TestClass]
    public class CitaServiciosTest
    {
        private IConexion? iConexion;
        private CitaServicios? entidad;

        public CitaServiciosTest()
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
            entidad = new CitaServicios
            {
                ID_Cita = iConexion?.Citas!.First().ID_Cita,
                ID_Servicio = iConexion?.Servicios!.First().ID_Servicio,
                PrecioCobrado = 20000m,
                DescuentoAplicado = 0m
            };
            iConexion?.CitaServicios!.Add(entidad);
            iConexion?.SaveChanges();
            return entidad.ID_CitaServicio > 0;
        }

        private bool Modificar()
        {
            entidad!.PrecioCobrado = 25000m;
            var entry = this.iConexion!.Entry(this.entidad!);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        private bool Listar() => iConexion?.CitaServicios!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion?.CitaServicios!.Remove(entidad!);
            iConexion?.SaveChanges();
            return true;
        }
    }
}
