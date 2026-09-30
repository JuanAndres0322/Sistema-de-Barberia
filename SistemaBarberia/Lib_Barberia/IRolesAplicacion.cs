using lib_Barberia.Entidades;

namespace lib_Barberia.Interfaces
{
    public interface IRolesAplicacion
    {
        void Configurar(string StringConexion);
        List<Roles> Listar();
        Roles Guardar(Roles entidad);
        Roles Modificar(Roles entidad);
        Roles Borrar(Roles entidad);
    }
}
