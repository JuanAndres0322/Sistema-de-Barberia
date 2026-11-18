using lib_Barberia.Entidades;
using Web_Barberia.Acceso;

namespace Web_Barberia.Controllers
{
    public class ClientesController : CrudController<Clientes>
    {
        public ClientesController(ApiClient api) : base(api, "Clientes") { }
    }
}
