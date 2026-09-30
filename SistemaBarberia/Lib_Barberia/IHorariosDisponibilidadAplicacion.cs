using lib_Barberia.Entidades;

namespace lib_Barberia.Interfaces
{
    public interface IHorariosDisponibilidadAplicacion
    {
        void Configurar(string StringConexion);
        List<HorariosDisponibilidad> Listar();
        HorariosDisponibilidad Guardar(HorariosDisponibilidad entidad);
        HorariosDisponibilidad Modificar(HorariosDisponibilidad entidad);
        HorariosDisponibilidad Borrar(HorariosDisponibilidad entidad);
    }
}
