using lib_Barberia.Entidades;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Barberia.Implementaciones
{
    public class ServiciosAplicacion : IServiciosAplicacion
    {
        private IConexion? iConexion = null;

        public ServiciosAplicacion(IConexion iConexion)
        {
            this.iConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.iConexion!.StringConexion = StringConexion;
        }

        public List<Servicios> Listar()
        {
            return this.iConexion!.Servicios!.ToList();
        }

        public Servicios Guardar(Servicios entidad)
        {
            this.iConexion!.Servicios!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Servicios Modificar(Servicios entidad)
        {
            var entry = this.iConexion!.Entry<Servicios>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Servicios Borrar(Servicios entidad)
        {
            this.iConexion!.Servicios!.Remove(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}
