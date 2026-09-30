using lib_Barberia.Entidades;

namespace lib_Barberia.Interfaces
{
    public interface IPermisosAplicacion
    {
        void Configurar(string StringConexion);
        List<Permisos> Listar();
        Permisos Guardar(Permisos entidad);
        Permisos Modificar(Permisos entidad);
        Permisos Borrar(Permisos entidad);
    }
}
