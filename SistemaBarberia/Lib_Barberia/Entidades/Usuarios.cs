namespace lib_Barberia.Entidades
{
    public class Usuarios
    {
        public int ID_Usuario { get; set; }

        public int? ID_Rol { get; set; }
        public Roles? Rol { get; set; }

        public int? ID_Barbero { get; set; }
        public Barberos? Barbero { get; set; }

        public string NombreUsuario { get; set; } = null!;
        public string HashContrasena { get; set; } = null!;
        public DateTime? UltimoAcceso { get; set; }
    }
}
