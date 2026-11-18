using lib_Barberia.Entidades;
using Web_Barberia.Acceso;

namespace Web_Barberia.Controllers
{
    public class CajasDiariasController : CrudController<CajasDiarias>
    {
        public CajasDiariasController(ApiClient api) : base(api, "CajasDiarias") { }
    }
}
