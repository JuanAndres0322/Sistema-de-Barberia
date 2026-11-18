using lib_Barberia.Entidades;
using Web_Barberia.Acceso;

namespace Web_Barberia.Controllers
{
    public class HorariosDisponibilidadController : CrudController<HorariosDisponibilidad>
    {
        public HorariosDisponibilidadController(ApiClient api) : base(api, "HorariosDisponibilidad") { }
    }
}
