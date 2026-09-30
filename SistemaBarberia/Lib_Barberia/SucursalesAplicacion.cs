using lib_Barberia.Entidades;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Barberia.Implementaciones
{
    public class SucursalesAplicacion : ISucursalesAplicacion
    {
        private IConexion? iConexion = null;

        public SucursalesAplicacion(IConexion iConexion)
        {
            this.iConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.iConexion!.StringConexion = StringConexion;
        }

        public List<Sucursales> Listar()
        {
            return this.iConexion!.Sucursales!.ToList();
        }

        public Sucursales Guardar(Sucursales entidad)
        {
            this.iConexion!.Sucursales!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Sucursales Modificar(Sucursales entidad)
        {
            var entry = this.iConexion!.Entry<Sucursales>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Sucursales Borrar(Sucursales entidad)
        {
            this.iConexion!.Sucursales!.Remove(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}
