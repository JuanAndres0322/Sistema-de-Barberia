using lib_Barberia.Entidades;

namespace Web_Barberia.Acceso
{
    public record EntidadInfo(string Ruta, string Titulo, string Grupo, Type Tipo);

    public static class Catalogo
    {
        public static readonly IReadOnlyList<EntidadInfo> Todas = new List<EntidadInfo>
        {
            new("Citas", "Citas", "Agenda", typeof(Citas)),
            new("CitaServicios", "Servicios por cita", "Agenda", typeof(CitaServicios)),
            new("HorariosDisponibilidad", "Horarios", "Agenda", typeof(HorariosDisponibilidad)),

            new("Clientes", "Clientes", "Personas", typeof(Clientes)),
            new("Barberos", "Barberos", "Personas", typeof(Barberos)),
            new("Usuarios", "Usuarios", "Personas", typeof(Usuarios)),

            new("Servicios", "Servicios", "Ventas y caja", typeof(Servicios)),
            new("Promociones", "Promociones", "Ventas y caja", typeof(Promociones)),
            new("VentaProductos", "Ventas", "Ventas y caja", typeof(VentaProductos)),
            new("DetalleVentaProductos", "Detalle de ventas", "Ventas y caja", typeof(DetalleVentaProductos)),
            new("Pagos", "Pagos", "Ventas y caja", typeof(Pagos)),
            new("MetodosPago", "Métodos de pago", "Ventas y caja", typeof(MetodosPago)),
            new("CajasDiarias", "Cajas diarias", "Ventas y caja", typeof(CajasDiarias)),

            new("Productos", "Productos", "Inventario", typeof(Productos)),
            new("CategoriasProducto", "Categorías", "Inventario", typeof(CategoriasProducto)),
            new("Proveedores", "Proveedores", "Inventario", typeof(Proveedores)),

            new("Sucursales", "Sucursales", "Sedes y accesos", typeof(Sucursales)),
            new("Roles", "Roles", "Sedes y accesos", typeof(Roles)),
            new("Permisos", "Permisos", "Sedes y accesos", typeof(Permisos)),
            new("RolPermisos", "Permisos por rol", "Sedes y accesos", typeof(RolPermisos)),
        };

        public static EntidadInfo? Buscar(string ruta) => Todas.FirstOrDefault(e => e.Ruta == ruta);

        // llave foranea
        public static readonly IReadOnlyDictionary<string, string> Relaciones = new Dictionary<string, string>
        {
            ["ID_Cliente"] = "Clientes",
            ["ID_Barbero"] = "Barberos",
            ["ID_Cita"] = "Citas",
            ["ID_Servicio"] = "Servicios",
            ["ID_Metodo"] = "MetodosPago",
            ["ID_Categoria"] = "CategoriasProducto",
            ["ID_Proveedor"] = "Proveedores",
            ["ID_Producto"] = "Productos",
            ["ID_Venta"] = "VentaProductos",
            ["ID_Sucursal"] = "Sucursales",
            ["ID_Rol"] = "Roles",
            ["ID_Permiso"] = "Permisos",
        };
    }
}
