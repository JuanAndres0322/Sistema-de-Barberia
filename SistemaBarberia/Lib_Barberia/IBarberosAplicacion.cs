using lib_Barberia.Entidades;

namespace lib_Barberia.Interfaces
{
    public interface IBarberosAplicacion
    {
        void Configurar(string StringConexion);
        List<Barberos> Listar();
        Barberos Guardar(Barberos entidad);
        Barberos Modificar(Barberos entidad);
        Barberos Borrar(Barberos entidad);
    }
}
