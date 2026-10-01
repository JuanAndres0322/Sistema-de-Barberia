using lib_Barberia.Entidades;
using lib_Barberia.Interfaces;
using Lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lib_Barberia.Implementaciones
{
    public class CategoriasProductoAplicacion : ICategoriasProductoAplicacion
    {
        private IConexion? iConexion = null;

        public CategoriasProductoAplicacion(IConexion iConexion)
        {
            this.iConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.iConexion!.StringConexion = StringConexion;
        }

        public List<CategoriasProducto> Listar()
        {
            return this.iConexion!.CategoriasProducto!.ToList();
        }

        public CategoriasProducto Guardar(CategoriasProducto entidad)
        {
            this.iConexion!.CategoriasProducto!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public CategoriasProducto Modificar(CategoriasProducto entidad)
        {
            var entry = this.iConexion!.Entry<CategoriasProducto>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return entidad;
        }

        public CategoriasProducto Borrar(CategoriasProducto entidad)
        {
            this.iConexion!.CategoriasProducto!.Remove(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}
