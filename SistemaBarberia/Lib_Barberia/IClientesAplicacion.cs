using lib_Barberia.Entidades;

namespace lib_Barberia.Interfaces
{
    public interface IClientesAplicacion
    {
        void Configurar(string StringConexion);
        List<Clientes> Listar();
        Clientes Guardar(Clientes entidad);
        Clientes Modificar(Clientes entidad);
        Clientes Borrar(Clientes entidad);
    }
}
