using System.ComponentModel.DataAnnotations.Schema;
namespace lib_Barberia.Entidades
{
    public class Citas
    {
        public int ID_Cita { get; set; }

        public int? ID_Cliente { get; set; }
        [ForeignKey("ID_Cliente")]
        public Clientes? Cliente { get; set; } 

        public int? ID_Barbero { get; set; }
        [ForeignKey("ID_Barbero")]
        public Barberos? Barbero { get; set; }

        public DateTime? FechaHora { get; set; }
        public string? Estado { get; set; }
        public string? NotasAdicionales { get; set; }

        public List<CitaServicios>? CitaServicios { get; set; }
        public List<Pagos>? Pagos { get; set; }
    }
}
