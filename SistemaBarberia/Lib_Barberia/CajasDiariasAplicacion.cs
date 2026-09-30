using lib_Barberia.Entidades;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Barberia.Implementaciones
{
    public class CajasDiariasAplicacion : ICajasDiariasAplicacion
    {
        private IConexion? iConexion = null;

        public CajasDiariasAplicacion(IConexion iConexion)
        {
            this.iConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.iConexion!.StringConexion = StringConexion;
        }

        public List<CajasDiarias> Listar()
        {
            return this.iConexion!.CajasDiarias!.ToList();
        }

        public CajasDiarias Guardar(CajasDiarias entidad)
        {
            this.iConexion!.CajasDiarias!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public CajasDiarias Modificar(CajasDiarias entidad)
        {
            var entry = this.iConexion!.Entry<CajasDiarias>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return entidad;
        }

        public CajasDiarias Borrar(CajasDiarias entidad)
        {
            this.iConexion!.CajasDiarias!.Remove(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}
