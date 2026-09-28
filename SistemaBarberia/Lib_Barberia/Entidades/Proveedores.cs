namespace lib_Barberia.Entidades
{
    public class Proveedores
    {
        public int ID_Proveedor { get; set; }
        public string NIT { get; set; } = null!;
        public string NombreEmpresa { get; set; } = null!;
        public string? ContactoPrincipal { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }

        public List<Productos>? Productos { get; set; }
    }
}
