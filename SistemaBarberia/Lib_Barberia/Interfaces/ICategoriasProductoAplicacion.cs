using lib_Barberia.Entidades;

namespace Lib_Barberia.Interfaces
{
    public interface ICategoriasProductoAplicacion
    {
        void Configurar(string StringConexion);
        List<CategoriasProducto> Listar();
        CategoriasProducto Guardar(CategoriasProducto entidad);
        CategoriasProducto Modificar(CategoriasProducto entidad);
        CategoriasProducto Borrar(CategoriasProducto entidad);
    }
}
