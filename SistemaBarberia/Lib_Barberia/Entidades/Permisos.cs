using System.ComponentModel.DataAnnotations;
namespace lib_Barberia.Entidades
{
    public class Permisos
    {
        [Key]
        public int ID_Permiso { get; set; }
        public string NombrePermiso { get; set; } = null!;
        public string? ModuloApp { get; set; }
        public string? Descripcion { get; set; }

        public List<RolPermisos>? RolPermisos { get; set; }
    }
}
