using System.ComponentModel.DataAnnotations;
namespace lib_Barberia.Entidades
{
    public class Roles
    {
        [Key]
        public int ID_Rol { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public bool? Activo { get; set; }

        public List<RolPermisos>? RolPermisos { get; set; }
        public List<Usuarios>? Usuarios { get; set; }
    }
}
