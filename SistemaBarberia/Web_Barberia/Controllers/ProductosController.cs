using lib_Barberia.Entidades;
using Web_Barberia.Acceso;

namespace Web_Barberia.Controllers
{
    public class ProductosController : CrudController<Productos>
    {
        public ProductosController(ApiClient api) : base(api, "Productos") { }
    }
}
