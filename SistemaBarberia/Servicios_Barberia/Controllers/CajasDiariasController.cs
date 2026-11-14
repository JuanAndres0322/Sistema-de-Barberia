using lib_Barberia.Entidades;
using Lib_Barberia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_horarios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CajasDiariasController : ControllerBase
    {
        private readonly ICajasDiariasAplicacion _CajasDiariasAplicacion;

        public CajasDiariasController(ICajasDiariasAplicacion CajasDiariasAplicacion)
        {
            _CajasDiariasAplicacion = CajasDiariasAplicacion;
        }

        // GET: /CajasDiarias/Listar
        [HttpGet]
        public List<CajasDiarias> Listar()
        {
            return _CajasDiariasAplicacion.Listar();
        }

        // POST: /CajasDiarias/Guardar
        [HttpPost]
        public CajasDiarias Guardar([FromBody] CajasDiarias entidad)
        {
            return _CajasDiariasAplicacion.Guardar(entidad);
        }

        // PUT: /CajasDiarias/Modificar
        [HttpPut]
        public CajasDiarias Modificar([FromBody] CajasDiarias entidad)
        {
            return _CajasDiariasAplicacion.Modificar(entidad);
        }

        // DELETE: /CajasDiarias/Borrar
        [HttpDelete]
        public CajasDiarias Borrar([FromBody] CajasDiarias entidad)
        {
            return _CajasDiariasAplicacion.Borrar(entidad);
        }
    }
}