using lib_Barberia.Entidades;
using Lib_Barberia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_horarios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CategoriasProductoController : ControllerBase
    {
        private readonly ICategoriasProductoAplicacion _CategoriasProductoAplicacion;

        public CategoriasProductoController(ICategoriasProductoAplicacion CategoriasProductoAplicacion)
        {
            _CategoriasProductoAplicacion = CategoriasProductoAplicacion;
        }

        // GET: /CategoriasProducto/Listar
        [HttpGet]
        public List<CategoriasProducto> Listar()
        {
            return _CategoriasProductoAplicacion.Listar();
        }

        // POST: /CategoriasProducto/Guardar
        [HttpPost]
        public CategoriasProducto Guardar([FromBody] CategoriasProducto entidad)
        {
            return _CategoriasProductoAplicacion.Guardar(entidad);
        }

        // PUT: /CategoriasProducto/Modificar
        [HttpPut]
        public CategoriasProducto Modificar([FromBody] CategoriasProducto entidad)
        {
            return _CategoriasProductoAplicacion.Modificar(entidad);
        }

        // DELETE: /CategoriasProducto/Borrar
        [HttpDelete]
        public CategoriasProducto Borrar([FromBody] CategoriasProducto entidad)
        {
            return _CategoriasProductoAplicacion.Borrar(entidad);
        }
    }
}