namespace lib_Barberia.Entidades
{
    public class HorariosDisponibilidad
    {
        public int ID_Horario { get; set; }

        public int? ID_Barbero { get; set; }
        public Barberos? Barbero { get; set; }

        public string? DiaSemana { get; set; }
        public TimeSpan? HoraInicio { get; set; } 
        public TimeSpan? HoraFin { get; set; }
        public string? Estado { get; set; }
    }
}
