namespace lib_Barberia.Entidades
{
    public class Barberos
    {
        public int ID_Barbero { get; set; }
        public string Cedula { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? Telefono { get; set; }
        public string? Especialidad { get; set; }
        public bool? Activo { get; set; }

        public List<Citas>? Citas { get; set; }
        public List<HorariosDisponibilidad>? HorariosDisponibilidad { get; set; }
        public List<VentaProductos>? VentaProductos { get; set; }
        public List<Usuarios>? Usuarios { get; set; }
    }
}
