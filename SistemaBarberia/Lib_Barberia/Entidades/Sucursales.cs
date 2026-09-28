namespace lib_Barberia.Entidades
{
    public class Sucursales
    {
        public int ID_Sucursal { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Ciudad { get; set; }
        public bool? Activa { get; set; }

        public List<CajasDiarias>? CajasDiarias { get; set; }
    }
}
