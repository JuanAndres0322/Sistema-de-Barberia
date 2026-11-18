using lib_Barberia.Entidades;
using Web_Barberia.Acceso;

namespace Web_Barberia.Controllers
{
    public class CategoriasProductoController : CrudController<CategoriasProducto>
    {
        public CategoriasProductoController(ApiClient api) : base(api, "CategoriasProducto") { }
    }
}
