using lib_Barberia.Entidades;

namespace lib_Barberia.Interfaces
{
    public interface IUsuariosAplicacion
    {
        void Configurar(string StringConexion);
        List<Usuarios> Listar();
        Usuarios Guardar(Usuarios entidad);
        Usuarios Modificar(Usuarios entidad);
        Usuarios Borrar(Usuarios entidad);
    }
}
