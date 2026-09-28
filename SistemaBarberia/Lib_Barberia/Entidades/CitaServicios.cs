namespace lib_Barberia.Entidades
{
    public class CitaServicios
    {
        public int ID_CitaServicio { get; set; }

        public int? ID_Cita { get; set; }
        public Citas? Cita { get; set; }

        public int? ID_Servicio { get; set; }
        public Servicios? Servicio { get; set; } 

        public decimal? PrecioCobrado { get; set; }
        public decimal? DescuentoAplicado { get; set; }
    }
}
