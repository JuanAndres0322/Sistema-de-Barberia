using System.ComponentModel.DataAnnotations.Schema;
namespace lib_Barberia.Entidades
{
    public class CitaServicios
    {
        [Column("ID_Cita_Servicio")]
        public int ID_CitaServicio { get; set; }

        public int? ID_Cita { get; set; }
        [ForeignKey("ID_Cita")]
        public Citas? Cita { get; set; }

        public int? ID_Servicio { get; set; }
        [ForeignKey("ID_Servicio")]
        public Servicios? Servicio { get; set; } 

        public decimal? PrecioCobrado { get; set; }
        public decimal? DescuentoAplicado { get; set; }
    }
}
