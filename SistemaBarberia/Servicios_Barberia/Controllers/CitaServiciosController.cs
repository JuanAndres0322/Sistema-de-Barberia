using lib_Barberia.Entidades;
using Lib_Barberia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_horarios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CitaServiciosController : ControllerBase
    {
        private readonly ICitaServiciosAplicacion _CitaServiciosAplicacion;

        public CitaServiciosController(ICitaServiciosAplicacion CitaServiciosAplicacion)
        {
            _CitaServiciosAplicacion = CitaServiciosAplicacion;
        }

        // GET: /CitaServicios/Listar
        [HttpGet]
        public List<CitaServicios> Listar()
        {
            return _CitaServiciosAplicacion.Listar();
        }

        // POST: /CitaServicios/Guardar
        [HttpPost]
        public CitaServicios Guardar([FromBody] CitaServicios entidad)
        {
            return _CitaServiciosAplicacion.Guardar(entidad);
        }

        // PUT: /CitaServicios/Modificar
        [HttpPut]
        public CitaServicios Modificar([FromBody] CitaServicios entidad)
        {
            return _CitaServiciosAplicacion.Modificar(entidad);
        }

        // DELETE: /CitaServicios/Borrar
        [HttpDelete]
        public CitaServicios Borrar([FromBody] CitaServicios entidad)
        {
            return _CitaServiciosAplicacion.Borrar(entidad);
        }
    }
}