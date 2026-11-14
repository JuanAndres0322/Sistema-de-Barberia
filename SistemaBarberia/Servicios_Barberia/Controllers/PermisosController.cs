using lib_Barberia.Entidades;
using Lib_Barberia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_horarios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PermisosController : ControllerBase
    {
        private readonly IPermisosAplicacion _PermisosAplicacion;

        public PermisosController(IPermisosAplicacion PermisosAplicacion)
        {
            _PermisosAplicacion = PermisosAplicacion;
        }

        // GET: /Permisos/Listar
        [HttpGet]
        public List<Permisos> Listar()
        {
            return _PermisosAplicacion.Listar();
        }

        // POST: /Permisos/Guardar
        [HttpPost]
        public Permisos Guardar([FromBody] Permisos entidad)
        {
            return _PermisosAplicacion.Guardar(entidad);
        }

        // PUT: /Permisos/Modificar
        [HttpPut]
        public Permisos Modificar([FromBody] Permisos entidad)
        {
            return _PermisosAplicacion.Modificar(entidad);
        }

        // DELETE: /Permisos/Borrar
        [HttpDelete]
        public Permisos Borrar([FromBody] Permisos entidad)
        {
            return _PermisosAplicacion.Borrar(entidad);
        }
    }
}