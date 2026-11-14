using lib_Barberia.Entidades;
using Lib_Barberia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_horarios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosAplicacion _UsuariosAplicacion;

        public UsuariosController(IUsuariosAplicacion UsuariosAplicacion)
        {
            _UsuariosAplicacion = UsuariosAplicacion;
        }

        // GET: /Usuarios/Listar
        [HttpGet]
        public List<Usuarios> Listar()
        {
            return _UsuariosAplicacion.Listar();
        }

        // POST: /Usuarios/Guardar
        [HttpPost]
        public Usuarios Guardar([FromBody] Usuarios entidad)
        {
            return _UsuariosAplicacion.Guardar(entidad);
        }

        // PUT: /Usuarios/Modificar
        [HttpPut]
        public Usuarios Modificar([FromBody] Usuarios entidad)
        {
            return _UsuariosAplicacion.Modificar(entidad);
        }

        // DELETE: /Usuarios/Borrar
        [HttpDelete]
        public Usuarios Borrar([FromBody] Usuarios entidad)
        {
            return _UsuariosAplicacion.Borrar(entidad);
        }
    }
}