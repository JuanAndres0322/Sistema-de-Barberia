using lib_Barberia.Entidades;
using Web_Barberia.Acceso;

namespace Web_Barberia.Controllers
{
    public class RolPermisosController : CrudController<RolPermisos>
    {
        public RolPermisosController(ApiClient api) : base(api, "RolPermisos") { }
    }
}
