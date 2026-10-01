using System.ComponentModel.DataAnnotations.Schema;
namespace lib_Barberia.Entidades
{
    public class Usuarios
    {
        public int ID_Usuario { get; set; }

        public int? ID_Rol { get; set; }
        [ForeignKey("ID_Rol")]
        public Roles? Rol { get; set; }

        public int? ID_Barbero { get; set; }
        [ForeignKey("ID_Barbero")]
        public Barberos? Barbero { get; set; }

        public string NombreUsuario { get; set; } = null!;
        public string HashContrasena { get; set; } = null!;
        public DateTime? UltimoAcceso { get; set; }
    }
}
