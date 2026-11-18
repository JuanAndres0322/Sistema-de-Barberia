using lib_Barberia.Entidades;
using Web_Barberia.Acceso;

namespace Web_Barberia.Controllers
{
    public class CitaServiciosController : CrudController<CitaServicios>
    {
        public CitaServiciosController(ApiClient api) : base(api, "CitaServicios") { }
    }
}
