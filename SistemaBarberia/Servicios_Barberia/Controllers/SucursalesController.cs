using lib_Barberia.Entidades;
using Lib_Barberia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_horarios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SucursalesController : ControllerBase
    {
        private readonly ISucursalesAplicacion _SucursalesAplicacion;

        public SucursalesController(ISucursalesAplicacion SucursalesAplicacion)
        {
            _SucursalesAplicacion = SucursalesAplicacion;
        }

        // GET: /Sucursales/Listar
        [HttpGet]
        public List<Sucursales> Listar()
        {
            return _SucursalesAplicacion.Listar();
        }

        // POST: /Sucursales/Guardar
        [HttpPost]
        public Sucursales Guardar([FromBody] Sucursales entidad)
        {
            return _SucursalesAplicacion.Guardar(entidad);
        }

        // PUT: /Sucursales/Modificar
        [HttpPut]
        public Sucursales Modificar([FromBody] Sucursales entidad)
        {
            return _SucursalesAplicacion.Modificar(entidad);
        }

        // DELETE: /Sucursales/Borrar
        [HttpDelete]
        public Sucursales Borrar([FromBody] Sucursales entidad)
        {
            return _SucursalesAplicacion.Borrar(entidad);
        }
    }
}