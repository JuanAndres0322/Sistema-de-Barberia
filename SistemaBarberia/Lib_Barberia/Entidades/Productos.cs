namespace lib_Barberia.Entidades
{
    public class Productos
    {
        public int ID_Producto { get; set; }

        public int? ID_Categoria { get; set; }
        public CategoriasProducto? Categoria { get; set; }

        public int? ID_Proveedor { get; set; }
        public Proveedores? Proveedor { get; set; }

        public string Nombre { get; set; } = null!;
        public string? CodigoBarras { get; set; }
        public decimal? PrecioVenta { get; set; }
        public int? StockActual { get; set; }

        public List<DetalleVentaProductos>? DetallesVenta { get; set; }
    }
}
