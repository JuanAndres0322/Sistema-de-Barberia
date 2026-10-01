using lib_Barberia.Entidades;

namespace Lib_Barberia.Interfaces
{
    public interface ICitaServiciosAplicacion
    {
        void Configurar(string StringConexion);
        List<CitaServicios> Listar();
        CitaServicios Guardar(CitaServicios entidad);
        CitaServicios Modificar(CitaServicios entidad);
        CitaServicios Borrar(CitaServicios entidad);
    }
}
