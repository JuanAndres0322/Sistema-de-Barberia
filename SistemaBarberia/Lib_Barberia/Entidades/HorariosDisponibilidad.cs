using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lib_Barberia.Entidades
{
    public class HorariosDisponibilidad
    {
        [Key]
        public int ID_Horario { get; set; }

        public int? ID_Barbero { get; set; }
        [ForeignKey("ID_Barbero")]
        public Barberos? Barbero { get; set; }

        public string? DiaSemana { get; set; }
        public TimeSpan? HoraInicio { get; set; } 
        public TimeSpan? HoraFin { get; set; }
        public string? Estado { get; set; }
    }
}
