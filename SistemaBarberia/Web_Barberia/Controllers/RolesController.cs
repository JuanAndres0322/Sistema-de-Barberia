using lib_Barberia.Entidades;
using Web_Barberia.Acceso;

namespace Web_Barberia.Controllers
{
    public class RolesController : CrudController<Roles>
    {
        public RolesController(ApiClient api) : base(api, "Roles") { }
    }
}
