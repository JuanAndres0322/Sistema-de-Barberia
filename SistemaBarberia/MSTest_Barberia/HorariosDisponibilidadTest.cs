using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    [TestClass]
    public class HorariosDisponibilidadTest : BaseTest
    {
        private HorariosDisponibilidad? entidad;

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
            entidad = new HorariosDisponibilidad
            {
                ID_Barbero = iConexion.Barberos!.First().ID_Barbero,
                DiaSemana = "Sabado",
                HoraInicio = new TimeSpan(9, 0, 0),
                HoraFin = new TimeSpan(17, 0, 0),
                Estado = "Activo"
            };
            iConexion.HorariosDisponibilidad!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Horario > 0;
        }

        private bool Modificar()
        {
            entidad!.Estado = "Inactivo";
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.HorariosDisponibilidad!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.HorariosDisponibilidad!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }
}
