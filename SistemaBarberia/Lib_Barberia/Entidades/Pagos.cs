using System.ComponentModel.DataAnnotations.Schema;
namespace lib_Barberia.Entidades
{
    public class Pagos
    {
        public int ID_Pago { get; set; }

        public int? ID_Cita { get; set; }
        [ForeignKey("ID_Cita")]
        public Citas? Cita { get; set; }

        public int? ID_Metodo { get; set; }
        [ForeignKey("ID_Metodo")]
        public MetodosPago? MetodoPago { get; set; }

        public decimal? MontoTotal { get; set; }
        public DateTime? FechaPago { get; set; }
        public string? ReferenciaVoucher { get; set; }
    }
}
