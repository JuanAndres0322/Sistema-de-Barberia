namespace lib_Barberia.Entidades
{
    public class CategoriasProducto
    {
        public int ID_Categoria { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public bool? Activo { get; set; }

        public List<Productos>? Productos { get; set; }
    }
}
