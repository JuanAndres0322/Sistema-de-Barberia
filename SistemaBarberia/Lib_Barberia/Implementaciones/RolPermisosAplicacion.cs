using lib_Barberia.Entidades;
using lib_Barberia.Interfaces;
using Lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lib_Barberia.Implementaciones
{
    public class RolPermisosAplicacion : IRolPermisosAplicacion
    {
        private IConexion? iConexion = null;

        public RolPermisosAplicacion(IConexion iConexion)
        {
            this.iConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.iConexion!.StringConexion = StringConexion;
        }

        public List<RolPermisos> Listar()
        {
            return this.iConexion!.RolPermisos!.ToList();
        }

        public RolPermisos Guardar(RolPermisos entidad)
        {
            this.iConexion!.RolPermisos!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public RolPermisos Modificar(RolPermisos entidad)
        {
            var entry = this.iConexion!.Entry<RolPermisos>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return entidad;
        }

        public RolPermisos Borrar(RolPermisos entidad)
        {
            this.iConexion!.RolPermisos!.Remove(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}
