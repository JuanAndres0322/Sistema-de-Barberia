using lib_Barberia.Entidades;
using Web_Barberia.Acceso;

namespace Web_Barberia.Controllers
{
    public class PromocionesController : CrudController<Promociones>
    {
        public PromocionesController(ApiClient api) : base(api, "Promociones") { }
    }
}
