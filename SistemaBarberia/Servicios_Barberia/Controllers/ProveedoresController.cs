using lib_Barberia.Entidades;
using Lib_Barberia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_horarios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProveedoresController : ControllerBase
    {
        private readonly IProveedoresAplicacion _ProveedoresAplicacion;

        public ProveedoresController(IProveedoresAplicacion ProveedoresAplicacion)
        {
            _ProveedoresAplicacion = ProveedoresAplicacion;
        }

        // GET: /Proveedores/Listar
        [HttpGet]
        public List<Proveedores> Listar()
        {
            return _ProveedoresAplicacion.Listar();
        }

        // POST: /Proveedores/Guardar
        [HttpPost]
        public Proveedores Guardar([FromBody] Proveedores entidad)
        {
            return _ProveedoresAplicacion.Guardar(entidad);
        }

        // PUT: /Proveedores/Modificar
        [HttpPut]
        public Proveedores Modificar([FromBody] Proveedores entidad)
        {
            return _ProveedoresAplicacion.Modificar(entidad);
        }

        // DELETE: /Proveedores/Borrar
        [HttpDelete]
        public Proveedores Borrar([FromBody] Proveedores entidad)
        {
            return _ProveedoresAplicacion.Borrar(entidad);
        }
    }
}