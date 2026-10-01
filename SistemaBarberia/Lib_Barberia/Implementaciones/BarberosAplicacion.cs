using lib_Barberia.Entidades;
using lib_Barberia.Interfaces;
using Lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lib_Barberia.Implementaciones
{
    public class BarberosAplicacion : IBarberosAplicacion
    {
        private IConexion? iConexion = null;

        public BarberosAplicacion(IConexion iConexion)
        {
            this.iConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.iConexion!.StringConexion = StringConexion;
        }

        public List<Barberos> Listar()
        {
            return this.iConexion!.Barberos!.ToList();
        }

        public Barberos Guardar(Barberos entidad)
        {
            this.iConexion!.Barberos!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Barberos Modificar(Barberos entidad)
        {
            var entry = this.iConexion!.Entry<Barberos>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Barberos Borrar(Barberos entidad)
        {
            this.iConexion!.Barberos!.Remove(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}
