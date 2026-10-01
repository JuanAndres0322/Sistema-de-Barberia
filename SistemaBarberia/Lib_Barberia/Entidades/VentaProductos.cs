using System.ComponentModel.DataAnnotations.Schema;
namespace lib_Barberia.Entidades
{
    public class VentaProductos
    {
        public int ID_Venta { get; set; }

        public int? ID_Cliente { get; set; }
        [ForeignKey("ID_Cliente")]
        public Clientes? Cliente { get; set; }

        public int? ID_Barbero { get; set; }
        [ForeignKey("ID_Barbero")]
        public Barberos? Barbero { get; set; }

        public DateTime? FechaVenta { get; set; }
        public decimal? TotalVenta { get; set; }
        public string? EstadoVenta { get; set; }

        public List<DetalleVentaProductos>? DetallesVenta { get; set; }
    }
}
