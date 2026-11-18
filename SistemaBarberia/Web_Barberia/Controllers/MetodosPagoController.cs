using lib_Barberia.Entidades;
using Web_Barberia.Acceso;

namespace Web_Barberia.Controllers
{
    public class MetodosPagoController : CrudController<MetodosPago>
    {
        public MetodosPagoController(ApiClient api) : base(api, "MetodosPago") { }
    }
}
