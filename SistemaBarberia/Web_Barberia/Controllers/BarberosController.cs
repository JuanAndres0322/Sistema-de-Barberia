using lib_Barberia.Entidades;
using Web_Barberia.Acceso;

namespace Web_Barberia.Controllers
{
    public class BarberosController : CrudController<Barberos>
    {
        public BarberosController(ApiClient api) : base(api, "Barberos") { }
    }
}
