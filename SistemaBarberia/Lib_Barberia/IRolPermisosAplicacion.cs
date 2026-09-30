using lib_Barberia.Entidades;

namespace lib_Barberia.Interfaces
{
    public interface IRolPermisosAplicacion
    {
        void Configurar(string StringConexion);
        List<RolPermisos> Listar();
        RolPermisos Guardar(RolPermisos entidad);
        RolPermisos Modificar(RolPermisos entidad);
        RolPermisos Borrar(RolPermisos entidad);
    }
}
