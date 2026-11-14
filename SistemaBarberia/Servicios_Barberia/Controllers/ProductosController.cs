using lib_Barberia.Entidades;
using Lib_Barberia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_horarios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductosAplicacion _ProductosAplicacion;

        public ProductosController(IProductosAplicacion ProductosAplicacion)
        {
            _ProductosAplicacion = ProductosAplicacion;
        }

        // GET: /Productos/Listar
        [HttpGet]
        public List<Productos> Listar()
        {
            return _ProductosAplicacion.Listar();
        }

        // POST: /Productos/Guardar
        [HttpPost]
        public Productos Guardar([FromBody] Productos entidad)
        {
            return _ProductosAplicacion.Guardar(entidad);
        }

        // PUT: /Productos/Modificar
        [HttpPut]
        public Productos Modificar([FromBody] Productos entidad)
        {
            return _ProductosAplicacion.Modificar(entidad);
        }

        // DELETE: /Productos/Borrar
        [HttpDelete]
        public Productos Borrar([FromBody] Productos entidad)
        {
            return _ProductosAplicacion.Borrar(entidad);
        }
    }
}