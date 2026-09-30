using lib_Barberia.Entidades;

namespace lib_Barberia.Interfaces
{
    public interface IMetodosPagoAplicacion
    {
        void Configurar(string StringConexion);
        List<MetodosPago> Listar();
        MetodosPago Guardar(MetodosPago entidad);
        MetodosPago Modificar(MetodosPago entidad);
        MetodosPago Borrar(MetodosPago entidad);
    }
}
