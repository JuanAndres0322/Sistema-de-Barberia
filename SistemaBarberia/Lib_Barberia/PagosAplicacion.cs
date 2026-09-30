using lib_Barberia.Entidades;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Barberia.Implementaciones
{
    public class PagosAplicacion : IPagosAplicacion
    {
        private IConexion? iConexion = null;

        public PagosAplicacion(IConexion iConexion)
        {
            this.iConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.iConexion!.StringConexion = StringConexion;
        }

        public List<Pagos> Listar()
        {
            return this.iConexion!.Pagos!.ToList();
        }

        public Pagos Guardar(Pagos entidad)
        {
            this.iConexion!.Pagos!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Pagos Modificar(Pagos entidad)
        {
            var entry = this.iConexion!.Entry<Pagos>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Pagos Borrar(Pagos entidad)
        {
            this.iConexion!.Pagos!.Remove(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}
