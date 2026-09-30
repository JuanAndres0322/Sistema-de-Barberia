using lib_Barberia.Entidades;

namespace lib_Barberia.Interfaces
{
    public interface IProductosAplicacion
    {
        void Configurar(string StringConexion);
        List<Productos> Listar();
        Productos Guardar(Productos entidad);
        Productos Modificar(Productos entidad);
        Productos Borrar(Productos entidad);
    }
}
