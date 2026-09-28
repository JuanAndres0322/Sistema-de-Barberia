namespace lib_Barberia.Entidades
{
    public class VentaProductos
    {
        public int ID_Venta { get; set; }

        public int? ID_Cliente { get; set; }
        public Clientes? Cliente { get; set; }

        public int? ID_Barbero { get; set; }
        public Barberos? Barbero { get; set; }

        public DateTime? FechaVenta { get; set; }
        public decimal? TotalVenta { get; set; }
        public string? EstadoVenta { get; set; }

        public List<DetalleVentaProductos>? DetallesVenta { get; set; }
    }
}
