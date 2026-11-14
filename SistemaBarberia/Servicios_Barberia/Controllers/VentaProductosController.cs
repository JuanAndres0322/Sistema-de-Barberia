using lib_Barberia.Entidades;
using Lib_Barberia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_horarios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class VentaProductosController : ControllerBase
    {
        private readonly IVentaProductosAplicacion _VentaProductosAplicacion;

        public VentaProductosController(IVentaProductosAplicacion VentaProductosAplicacion)
        {
            _VentaProductosAplicacion = VentaProductosAplicacion;
        }

        // GET: /VentaProductos/Listar
        [HttpGet]
        public List<VentaProductos> Listar()
        {
            return _VentaProductosAplicacion.Listar();
        }

        // POST: /VentaProductos/Guardar
        [HttpPost]
        public VentaProductos Guardar([FromBody] VentaProductos entidad)
        {
            return _VentaProductosAplicacion.Guardar(entidad);
        }

        // PUT: /VentaProductos/Modificar
        [HttpPut]
        public VentaProductos Modificar([FromBody] VentaProductos entidad)
        {
            return _VentaProductosAplicacion.Modificar(entidad);
        }

        // DELETE: /VentaProductos/Borrar
        [HttpDelete]
        public VentaProductos Borrar([FromBody] VentaProductos entidad)
        {
            return _VentaProductosAplicacion.Borrar(entidad);
        }
    }
}