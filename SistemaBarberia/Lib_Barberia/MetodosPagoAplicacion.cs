using lib_Barberia.Entidades;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Barberia.Implementaciones
{
    public class MetodosPagoAplicacion : IMetodosPagoAplicacion
    {
        private IConexion? iConexion = null;

        public MetodosPagoAplicacion(IConexion iConexion)
        {
            this.iConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.iConexion!.StringConexion = StringConexion;
        }

        public List<MetodosPago> Listar()
        {
            return this.iConexion!.MetodosPago!.ToList();
        }

        public MetodosPago Guardar(MetodosPago entidad)
        {
            this.iConexion!.MetodosPago!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public MetodosPago Modificar(MetodosPago entidad)
        {
            var entry = this.iConexion!.Entry<MetodosPago>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return entidad;
        }

        public MetodosPago Borrar(MetodosPago entidad)
        {
            this.iConexion!.MetodosPago!.Remove(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}
