using lib_Barberia.Entidades;
using Lib_Barberia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_horarios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RolPermisosController : ControllerBase
    {
        private readonly IRolPermisosAplicacion _RolPermisosAplicacion;

        public RolPermisosController(IRolPermisosAplicacion RolPermisosAplicacion)
        {
            _RolPermisosAplicacion = RolPermisosAplicacion;
        }

        // GET: /RolPermisos/Listar
        [HttpGet]
        public List<RolPermisos> Listar()
        {
            return _RolPermisosAplicacion.Listar();
        }

        // POST: /RolPermisos/Guardar
        [HttpPost]
        public RolPermisos Guardar([FromBody] RolPermisos entidad)
        {
            return _RolPermisosAplicacion.Guardar(entidad);
        }

        // PUT: /RolPermisos/Modificar
        [HttpPut]
        public RolPermisos Modificar([FromBody] RolPermisos entidad)
        {
            return _RolPermisosAplicacion.Modificar(entidad);
        }

        // DELETE: /RolPermisos/Borrar
        [HttpDelete]
        public RolPermisos Borrar([FromBody] RolPermisos entidad)
        {
            return _RolPermisosAplicacion.Borrar(entidad);
        }
    }
}