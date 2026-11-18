using lib_Barberia.Entidades;
using Web_Barberia.Acceso;

namespace Web_Barberia.Controllers
{
    public class ServiciosController : CrudController<Servicios>
    {
        public ServiciosController(ApiClient api) : base(api, "Servicios") { }
    }
}
