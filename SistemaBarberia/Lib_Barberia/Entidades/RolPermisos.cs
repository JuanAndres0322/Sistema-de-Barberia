using System.ComponentModel.DataAnnotations.Schema;
namespace lib_Barberia.Entidades
{
    public class RolPermisos
    {
        [Column("ID_Rol_Permiso")]
        public int ID_RolPermiso { get; set; }

        public int? ID_Rol { get; set; }
        [ForeignKey("ID_Rol")]
        public Roles? Rol { get; set; }

        public int? ID_Permiso { get; set; }
        [ForeignKey("ID_Permiso")]
        public Permisos? Permiso { get; set; }

        public DateTime? FechaAsignacion { get; set; }
        public bool? Habilitado { get; set; }
    }
}
