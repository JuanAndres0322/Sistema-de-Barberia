using lib_Barberia.Entidades;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Barberia.Implementaciones
{
    public class VentaProductosAplicacion : IVentaProductosAplicacion
    {
        private IConexion? iConexion = null;

        public VentaProductosAplicacion(IConexion iConexion)
        {
            this.iConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.iConexion!.StringConexion = StringConexion;
        }

        public List<VentaProductos> Listar()
        {
            return this.iConexion!.VentaProductos!.ToList();
        }

        public VentaProductos Guardar(VentaProductos entidad)
        {
            this.iConexion!.VentaProductos!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public VentaProductos Modificar(VentaProductos entidad)
        {
            var entry = this.iConexion!.Entry<VentaProductos>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return entidad;
        }

        public VentaProductos Borrar(VentaProductos entidad)
        {
            this.iConexion!.VentaProductos!.Remove(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}
