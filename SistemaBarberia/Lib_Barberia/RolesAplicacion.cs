using lib_Barberia.Entidades;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Barberia.Implementaciones
{
    public class RolesAplicacion : IRolesAplicacion
    {
        private IConexion? iConexion = null;

        public RolesAplicacion(IConexion iConexion)
        {
            this.iConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.iConexion!.StringConexion = StringConexion;
        }

        public List<Roles> Listar()
        {
            return this.iConexion!.Roles!.ToList();
        }

        public Roles Guardar(Roles entidad)
        {
            this.iConexion!.Roles!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Roles Modificar(Roles entidad)
        {
            var entry = this.iConexion!.Entry<Roles>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Roles Borrar(Roles entidad)
        {
            this.iConexion!.Roles!.Remove(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}
