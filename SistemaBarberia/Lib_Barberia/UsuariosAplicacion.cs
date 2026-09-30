using lib_Barberia.Entidades;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Barberia.Implementaciones
{
    public class UsuariosAplicacion : IUsuariosAplicacion
    {
        private IConexion? iConexion = null;

        public UsuariosAplicacion(IConexion iConexion)
        {
            this.iConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.iConexion!.StringConexion = StringConexion;
        }

        public List<Usuarios> Listar()
        {
            return this.iConexion!.Usuarios!.ToList();
        }

        public Usuarios Guardar(Usuarios entidad)
        {
            this.iConexion!.Usuarios!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Usuarios Modificar(Usuarios entidad)
        {
            var entry = this.iConexion!.Entry<Usuarios>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Usuarios Borrar(Usuarios entidad)
        {
            this.iConexion!.Usuarios!.Remove(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}
