using lib_Barberia.Entidades;
using Web_Barberia.Acceso;

namespace Web_Barberia.Controllers
{
    public class ProveedoresController : CrudController<Proveedores>
    {
        public ProveedoresController(ApiClient api) : base(api, "Proveedores") { }
    }
}
