using lib_Barberia.Entidades;
using Lib_Barberia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_horarios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ServiciosController : ControllerBase
    {
        private readonly IServiciosAplicacion _ServiciosAplicacion;

        public ServiciosController(IServiciosAplicacion ServiciosAplicacion)
        {
            _ServiciosAplicacion = ServiciosAplicacion;
        }

        // GET: /Servicios/Listar
        [HttpGet]
        public List<Servicios> Listar()
        {
            return _ServiciosAplicacion.Listar();
        }

        // POST: /Servicios/Guardar
        [HttpPost]
        public Servicios Guardar([FromBody] Servicios entidad)
        {
            return _ServiciosAplicacion.Guardar(entidad);
        }

        // PUT: /Servicios/Modificar
        [HttpPut]
        public Servicios Modificar([FromBody] Servicios entidad)
        {
            return _ServiciosAplicacion.Modificar(entidad);
        }

        // DELETE: /Servicios/Borrar
        [HttpDelete]
        public Servicios Borrar([FromBody] Servicios entidad)
        {
            return _ServiciosAplicacion.Borrar(entidad);
        }
    }
}