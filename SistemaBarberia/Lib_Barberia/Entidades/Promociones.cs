namespace lib_Barberia.Entidades
{
    public class Promociones
    {
        public int ID_Promocion { get; set; }
        public string Nombre { get; set; } = null!;
        public string? TipoDescuento { get; set; }
        public decimal? ValorDescuento { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public bool? Activo { get; set; }
    }
}
