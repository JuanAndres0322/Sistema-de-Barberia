using lib_Barberia.Entidades;
using Web_Barberia.Acceso;

namespace Web_Barberia.Controllers
{
    public class SucursalesController : CrudController<Sucursales>
    {
        public SucursalesController(ApiClient api) : base(api, "Sucursales") { }
    }
}
