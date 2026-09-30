using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    [TestClass]
    public class CitaServiciosTest : BaseTest
    {
        private CitaServicios? entidad;

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
                ID_Cita = iConexion.Citas!.First().ID_Cita,
                ID_Servicio = iConexion.Servicios!.First().ID_Servicio,
                PrecioCobrado = 20000m,
                DescuentoAplicado = 0m
            };
            iConexion.CitaServicios!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Cita_Servicio > 0;
        }

        private bool Modificar()
        {
            entidad!.PrecioCobrado = 25000m;
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.CitaServicios!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.CitaServicios!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }
}
