using lib_Barberia.Entidades;
using Web_Barberia.Acceso;

namespace Web_Barberia.Controllers
{
    public class UsuariosController : CrudController<Usuarios>
    {
        public UsuariosController(ApiClient api) : base(api, "Usuarios") { }
    }
}
