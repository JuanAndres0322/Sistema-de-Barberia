using lib_Barberia.Entidades;
using Lib_Barberia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_horarios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RolesController : ControllerBase
    {
        private readonly IRolesAplicacion _RolesAplicacion;

        public RolesController(IRolesAplicacion RolesAplicacion)
        {
            _RolesAplicacion = RolesAplicacion;
        }

        // GET: /Roles/Listar
        [HttpGet]
        public List<Roles> Listar()
        {
            return _RolesAplicacion.Listar();
        }

        // POST: /Roles/Guardar
        [HttpPost]
        public Roles Guardar([FromBody] Roles entidad)
        {
            return _RolesAplicacion.Guardar(entidad);
        }

        // PUT: /Roles/Modificar
        [HttpPut]
        public Roles Modificar([FromBody] Roles entidad)
        {
            return _RolesAplicacion.Modificar(entidad);
        }

        // DELETE: /Roles/Borrar
        [HttpDelete]
        public Roles Borrar([FromBody] Roles entidad)
        {
            return _RolesAplicacion.Borrar(entidad);
        }
    }
}