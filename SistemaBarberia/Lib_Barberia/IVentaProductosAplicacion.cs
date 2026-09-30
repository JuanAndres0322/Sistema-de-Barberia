using lib_Barberia.Entidades;

namespace lib_Barberia.Interfaces
{
    public interface IVentaProductosAplicacion
    {
        void Configurar(string StringConexion);
        List<VentaProductos> Listar();
        VentaProductos Guardar(VentaProductos entidad);
        VentaProductos Modificar(VentaProductos entidad);
        VentaProductos Borrar(VentaProductos entidad);
    }
}
