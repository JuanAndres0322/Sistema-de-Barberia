using lib_Barberia.Entidades;
using lib_Barberia.Interfaces;
using Lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lib_Barberia.Implementaciones
{
    public class ProductosAplicacion : IProductosAplicacion
    {
        private IConexion? iConexion = null;

        public ProductosAplicacion(IConexion iConexion)
        {
            this.iConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.iConexion!.StringConexion = StringConexion;
        }

        public List<Productos> Listar()
        {
            return this.iConexion!.Productos!.ToList();
        }

        public Productos Guardar(Productos entidad)
        {
            this.iConexion!.Productos!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Productos Modificar(Productos entidad)
        {
            var entry = this.iConexion!.Entry<Productos>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Productos Borrar(Productos entidad)
        {
            this.iConexion!.Productos!.Remove(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}
