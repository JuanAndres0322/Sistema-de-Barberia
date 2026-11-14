using lib_Barberia.Entidades;
using Lib_Barberia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_horarios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MetodosPagoController : ControllerBase
    {
        private readonly IMetodosPagoAplicacion _MetodosPagoAplicacion;

        public MetodosPagoController(IMetodosPagoAplicacion MetodosPagoAplicacion)
        {
            _MetodosPagoAplicacion = MetodosPagoAplicacion;
        }

        // GET: /MetodosPago/Listar
        [HttpGet]
        public List<MetodosPago> Listar()
        {
            return _MetodosPagoAplicacion.Listar();
        }

        // POST: /MetodosPago/Guardar
        [HttpPost]
        public MetodosPago Guardar([FromBody] MetodosPago entidad)
        {
            return _MetodosPagoAplicacion.Guardar(entidad);
        }

        // PUT: /MetodosPago/Modificar
        [HttpPut]
        public MetodosPago Modificar([FromBody] MetodosPago entidad)
        {
            return _MetodosPagoAplicacion.Modificar(entidad);
        }

        // DELETE: /MetodosPago/Borrar
        [HttpDelete]
        public MetodosPago Borrar([FromBody] MetodosPago entidad)
        {
            return _MetodosPagoAplicacion.Borrar(entidad);
        }
    }
}