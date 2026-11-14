using lib_Barberia.Entidades;
using Lib_Barberia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_horarios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CitasController : ControllerBase
    {
        private readonly ICitasAplicacion _CitasAplicacion;

        public CitasController(ICitasAplicacion CitasAplicacion)
        {
            _CitasAplicacion = CitasAplicacion;
        }

        // GET: /Citas/Listar
        [HttpGet]
        public List<Citas> Listar()
        {
            return _CitasAplicacion.Listar();
        }

        // POST: /Citas/Guardar
        [HttpPost]
        public Citas Guardar([FromBody] Citas entidad)
        {
            return _CitasAplicacion.Guardar(entidad);
        }

        // PUT: /Citas/Modificar
        [HttpPut]
        public Citas Modificar([FromBody] Citas entidad)
        {
            return _CitasAplicacion.Modificar(entidad);
        }

        // DELETE: /Citas/Borrar
        [HttpDelete]
        public Citas Borrar([FromBody] Citas entidad)
        {
            return _CitasAplicacion.Borrar(entidad);
        }
    }
}