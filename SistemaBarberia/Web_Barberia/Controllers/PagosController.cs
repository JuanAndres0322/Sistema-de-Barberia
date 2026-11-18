using lib_Barberia.Entidades;
using Web_Barberia.Acceso;

namespace Web_Barberia.Controllers
{
    public class PagosController : CrudController<Pagos>
    {
        public PagosController(ApiClient api) : base(api, "Pagos") { }
    }
}
