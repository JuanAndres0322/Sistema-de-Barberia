using lib_Barberia.Entidades;

namespace Lib_Barberia.Interfaces
{
    public interface ICitasAplicacion
    {
        void Configurar(string StringConexion);
        List<Citas> Listar();
        Citas Guardar(Citas entidad);
        Citas Modificar(Citas entidad);
        Citas Borrar(Citas entidad);
    }
}
