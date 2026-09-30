using lib_Barberia.Entidades;

namespace lib_Barberia.Interfaces
{
    public interface IDetalleVentaProductosAplicacion
    {
        void Configurar(string StringConexion);
        List<DetalleVentaProductos> Listar();
        DetalleVentaProductos Guardar(DetalleVentaProductos entidad);
        DetalleVentaProductos Modificar(DetalleVentaProductos entidad);
        DetalleVentaProductos Borrar(DetalleVentaProductos entidad);
    }
}
