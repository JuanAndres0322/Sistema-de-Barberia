using lib_Barberia.Entidades;
using Lib_Barberia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_horarios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PagosController : ControllerBase
    {
        private readonly IPagosAplicacion _PagosAplicacion;

        public PagosController(IPagosAplicacion PagosAplicacion)
        {
            _PagosAplicacion = PagosAplicacion;
        }

        // GET: /Pagos/Listar
        [HttpGet]
        public List<Pagos> Listar()
        {
            return _PagosAplicacion.Listar();
        }

        // POST: /Pagos/Guardar
        [HttpPost]
        public Pagos Guardar([FromBody] Pagos entidad)
        {
            return _PagosAplicacion.Guardar(entidad);
        }

        // PUT: /Pagos/Modificar
        [HttpPut]
        public Pagos Modificar([FromBody] Pagos entidad)
        {
            return _PagosAplicacion.Modificar(entidad);
        }

        // DELETE: /Pagos/Borrar
        [HttpDelete]
        public Pagos Borrar([FromBody] Pagos entidad)
        {
            return _PagosAplicacion.Borrar(entidad);
        }
    }
}