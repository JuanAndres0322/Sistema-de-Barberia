using lib_Barberia.Entidades;
using Lib_Barberia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_horarios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DetalleVentaProductosController : ControllerBase
    {
        private readonly IDetalleVentaProductosAplicacion _DetalleVentaProductosAplicacion;

        public DetalleVentaProductosController(IDetalleVentaProductosAplicacion DetalleVentaProductosAplicacion)
        {
            _DetalleVentaProductosAplicacion = DetalleVentaProductosAplicacion;
        }

        // GET: /DetalleVentaProductos/Listar
        [HttpGet]
        public List<DetalleVentaProductos> Listar()
        {
            return _DetalleVentaProductosAplicacion.Listar();
        }

        // POST: /DetalleVentaProductos/Guardar
        [HttpPost]
        public DetalleVentaProductos Guardar([FromBody] DetalleVentaProductos entidad)
        {
            return _DetalleVentaProductosAplicacion.Guardar(entidad);
        }

        // PUT: /DetalleVentaProductos/Modificar
        [HttpPut]
        public DetalleVentaProductos Modificar([FromBody] DetalleVentaProductos entidad)
        {
            return _DetalleVentaProductosAplicacion.Modificar(entidad);
        }

        // DELETE: /DetalleVentaProductos/Borrar
        [HttpDelete]
        public DetalleVentaProductos Borrar([FromBody] DetalleVentaProductos entidad)
        {
            return _DetalleVentaProductosAplicacion.Borrar(entidad);
        }
    }
}