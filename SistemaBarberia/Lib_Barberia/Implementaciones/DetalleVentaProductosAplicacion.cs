using lib_Barberia.Entidades;
using lib_Barberia.Interfaces;
using Lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lib_Barberia.Implementaciones
{
    public class DetalleVentaProductosAplicacion : IDetalleVentaProductosAplicacion
    {
        private IConexion? iConexion = null;

        public DetalleVentaProductosAplicacion(IConexion iConexion)
        {
            this.iConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.iConexion!.StringConexion = StringConexion;
        }

        public List<DetalleVentaProductos> Listar()
        {
            return this.iConexion!.DetalleVentaProductos!.ToList();
        }

        public DetalleVentaProductos Guardar(DetalleVentaProductos entidad)
        {
            this.iConexion!.DetalleVentaProductos!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public DetalleVentaProductos Modificar(DetalleVentaProductos entidad)
        {
            var entry = this.iConexion!.Entry<DetalleVentaProductos>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return entidad;
        }

        public DetalleVentaProductos Borrar(DetalleVentaProductos entidad)
        {
            this.iConexion!.DetalleVentaProductos!.Remove(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}
