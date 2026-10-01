using lib_Barberia.Entidades;

namespace Lib_Barberia.Interfaces
{
    public interface ISucursalesAplicacion
    {
        void Configurar(string StringConexion);
        List<Sucursales> Listar();
        Sucursales Guardar(Sucursales entidad);
        Sucursales Modificar(Sucursales entidad);
        Sucursales Borrar(Sucursales entidad);
    }
}
