using System.ComponentModel.DataAnnotations;
namespace lib_Barberia.Entidades
{
    public class Servicios
    {
        [Key]
        public int ID_Servicio { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int? DuracionMinutos { get; set; }
        public decimal? PrecioActual { get; set; }
        public bool? Activo { get; set; }

        public List<CitaServicios>? CitaServicios { get; set; }
    }
}
