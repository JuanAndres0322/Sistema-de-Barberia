using lib_Barberia.Entidades;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Barberia.Implementaciones
{
    public class CitaServiciosAplicacion : ICitaServiciosAplicacion
    {
        private IConexion? iConexion = null;

        public CitaServiciosAplicacion(IConexion iConexion)
        {
            this.iConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.iConexion!.StringConexion = StringConexion;
        }

        public List<CitaServicios> Listar()
        {
            return this.iConexion!.CitaServicios!.ToList();
        }

        public CitaServicios Guardar(CitaServicios entidad)
        {
            this.iConexion!.CitaServicios!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public CitaServicios Modificar(CitaServicios entidad)
        {
            var entry = this.iConexion!.Entry<CitaServicios>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return entidad;
        }

        public CitaServicios Borrar(CitaServicios entidad)
        {
            this.iConexion!.CitaServicios!.Remove(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}
