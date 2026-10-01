using lib_Barberia.Entidades;

namespace Lib_Barberia.Interfaces
{
    public interface IServiciosAplicacion
    {
        void Configurar(string StringConexion);
        List<Servicios> Listar();
        Servicios Guardar(Servicios entidad);
        Servicios Modificar(Servicios entidad);
        Servicios Borrar(Servicios entidad);
    }
}
