using lib_Barberia.Entidades;
using Web_Barberia.Acceso;

namespace Web_Barberia.Controllers
{
    public class DetalleVentaProductosController : CrudController<DetalleVentaProductos>
    {
        public DetalleVentaProductosController(ApiClient api) : base(api, "DetalleVentaProductos") { }
    }
}
