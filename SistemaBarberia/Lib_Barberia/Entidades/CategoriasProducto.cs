using System.ComponentModel.DataAnnotations;
namespace lib_Barberia.Entidades
{
    public class CategoriasProducto
    {
        [Key]
        public int ID_Categoria { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public bool? Activo { get; set; }

        public List<Productos>? Productos { get; set; }
    }
}
