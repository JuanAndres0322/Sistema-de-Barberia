using lib_Barberia.Entidades;
using Web_Barberia.Acceso;

namespace Web_Barberia.Controllers
{
    public class CitasController : CrudController<Citas>
    {
        public CitasController(ApiClient api) : base(api, "Citas") { }
    }
}
