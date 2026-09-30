using lib_Barberia.Entidades;

namespace lib_Barberia.Interfaces
{
    public interface ICajasDiariasAplicacion
    {
        void Configurar(string StringConexion);
        List<CajasDiarias> Listar();
        CajasDiarias Guardar(CajasDiarias entidad);
        CajasDiarias Modificar(CajasDiarias entidad);
        CajasDiarias Borrar(CajasDiarias entidad);
    }
}
