using lib_Barberia.Entidades;
using Web_Barberia.Acceso;

namespace Web_Barberia.Controllers
{
    public class PermisosController : CrudController<Permisos>
    {
        public PermisosController(ApiClient api) : base(api, "Permisos") { }
    }
}
