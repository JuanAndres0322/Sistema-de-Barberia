namespace lib_Barberia.Entidades
{
    public class Citas
    {
        public int ID_Cita { get; set; }

        public int? ID_Cliente { get; set; }
        public Clientes? Cliente { get; set; } 

        public int? ID_Barbero { get; set; }
        public Barberos? Barbero { get; set; }

        public DateTime? FechaHora { get; set; }
        public string? Estado { get; set; }
        public string? NotasAdicionales { get; set; }

        public List<CitaServicios>? CitaServicios { get; set; }
        public List<Pagos>? Pagos { get; set; }
    }
}
