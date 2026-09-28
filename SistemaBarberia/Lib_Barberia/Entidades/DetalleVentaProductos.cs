namespace lib_Barberia.Entidades
{
    public class DetalleVentaProductos
    {
        public int ID_Detalle { get; set; }

        public int? ID_Venta { get; set; }
        public VentaProductos? Venta { get; set; }

        public int? ID_Producto { get; set; }
        public Productos? Producto { get; set; }

        public int? Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
