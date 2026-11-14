using lib_Barberia.Entidades;
using Lib_Barberia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_horarios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PromocionesController : ControllerBase
    {
        private readonly IPromocionesAplicacion _PromocionesAplicacion;

        public PromocionesController(IPromocionesAplicacion PromocionesAplicacion)
        {
            _PromocionesAplicacion = PromocionesAplicacion;
        }

        // GET: /Promociones/Listar
        [HttpGet]
        public List<Promociones> Listar()
        {
            return _PromocionesAplicacion.Listar();
        }

        // POST: /Promociones/Guardar
        [HttpPost]
        public Promociones Guardar([FromBody] Promociones entidad)
        {
            return _PromocionesAplicacion.Guardar(entidad);
        }

        // PUT: /Promociones/Modificar
        [HttpPut]
        public Promociones Modificar([FromBody] Promociones entidad)
        {
            return _PromocionesAplicacion.Modificar(entidad);
        }

        // DELETE: /Promociones/Borrar
        [HttpDelete]
        public Promociones Borrar([FromBody] Promociones entidad)
        {
            return _PromocionesAplicacion.Borrar(entidad);
        }
    }
}