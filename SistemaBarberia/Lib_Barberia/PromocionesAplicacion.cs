using lib_Barberia.Entidades;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Barberia.Implementaciones
{
    public class PromocionesAplicacion : IPromocionesAplicacion
    {
        private IConexion? iConexion = null;

        public PromocionesAplicacion(IConexion iConexion)
        {
            this.iConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.iConexion!.StringConexion = StringConexion;
        }

        public List<Promociones> Listar()
        {
            return this.iConexion!.Promociones!.ToList();
        }

        public Promociones Guardar(Promociones entidad)
        {
            this.iConexion!.Promociones!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Promociones Modificar(Promociones entidad)
        {
            var entry = this.iConexion!.Entry<Promociones>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Promociones Borrar(Promociones entidad)
        {
            this.iConexion!.Promociones!.Remove(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}
