using lib_Barberia.Entidades;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Barberia.Implementaciones
{
    public class PermisosAplicacion : IPermisosAplicacion
    {
        private IConexion? iConexion = null;

        public PermisosAplicacion(IConexion iConexion)
        {
            this.iConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.iConexion!.StringConexion = StringConexion;
        }

        public List<Permisos> Listar()
        {
            return this.iConexion!.Permisos!.ToList();
        }

        public Permisos Guardar(Permisos entidad)
        {
            this.iConexion!.Permisos!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Permisos Modificar(Permisos entidad)
        {
            var entry = this.iConexion!.Entry<Permisos>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Permisos Borrar(Permisos entidad)
        {
            this.iConexion!.Permisos!.Remove(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}
