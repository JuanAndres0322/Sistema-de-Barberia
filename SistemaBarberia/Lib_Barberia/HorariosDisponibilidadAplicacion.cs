using lib_Barberia.Entidades;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Barberia.Implementaciones
{
    public class HorariosDisponibilidadAplicacion : IHorariosDisponibilidadAplicacion
    {
        private IConexion? iConexion = null;

        public HorariosDisponibilidadAplicacion(IConexion iConexion)
        {
            this.iConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.iConexion!.StringConexion = StringConexion;
        }

        public List<HorariosDisponibilidad> Listar()
        {
            return this.iConexion!.HorariosDisponibilidad!.ToList();
        }

        public HorariosDisponibilidad Guardar(HorariosDisponibilidad entidad)
        {
            this.iConexion!.HorariosDisponibilidad!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public HorariosDisponibilidad Modificar(HorariosDisponibilidad entidad)
        {
            var entry = this.iConexion!.Entry<HorariosDisponibilidad>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return entidad;
        }

        public HorariosDisponibilidad Borrar(HorariosDisponibilidad entidad)
        {
            this.iConexion!.HorariosDisponibilidad!.Remove(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}
