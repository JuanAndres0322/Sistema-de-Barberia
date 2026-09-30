using lib_Barberia.Entidades;

namespace lib_Barberia.Interfaces
{
    public interface IProveedoresAplicacion
    {
        void Configurar(string StringConexion);
        List<Proveedores> Listar();
        Proveedores Guardar(Proveedores entidad);
        Proveedores Modificar(Proveedores entidad);
        Proveedores Borrar(Proveedores entidad);
    }
}
