using lib_Barberia.Entidades;
using Lib_Barberia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_horarios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BarberosController : ControllerBase
    {
        private readonly IBarberosAplicacion _BarberosAplicacion;

        public BarberosController(IBarberosAplicacion BarberosAplicacion)
        {
            _BarberosAplicacion = BarberosAplicacion;
        }

        // GET: /Barberos/Listar
        [HttpGet]
        public List<Barberos> Listar()
        {
            return _BarberosAplicacion.Listar();
        }

        // POST: /Barberos/Guardar
        [HttpPost]
        public Barberos Guardar([FromBody] Barberos entidad)
        {
            return _BarberosAplicacion.Guardar(entidad);
        }

        // PUT: /Barberos/Modificar
        [HttpPut]
        public Barberos Modificar([FromBody] Barberos entidad)
        {
            return _BarberosAplicacion.Modificar(entidad);
        }

        // DELETE: /Barberos/Borrar
        [HttpDelete]
        public Barberos Borrar([FromBody] Barberos entidad)
        {
            return _BarberosAplicacion.Borrar(entidad);
        }
    }
}