using lib_Barberia.Entidades;
using Web_Barberia.Acceso;

namespace Web_Barberia.Controllers
{
    public class VentaProductosController : CrudController<VentaProductos>
    {
        public VentaProductosController(ApiClient api) : base(api, "VentaProductos") { }
    }
}
