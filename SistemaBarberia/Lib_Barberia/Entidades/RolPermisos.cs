namespace lib_Barberia.Entidades
{
    public class RolPermisos
    {
        public int ID_RolPermiso { get; set; }

        public int? ID_Rol { get; set; }
        public Roles? Rol { get; set; }

        public int? ID_Permiso { get; set; }
        public Permisos? Permiso { get; set; }

        public DateTime? FechaAsignacion { get; set; }
        public bool? Habilitado { get; set; }
    }
}
