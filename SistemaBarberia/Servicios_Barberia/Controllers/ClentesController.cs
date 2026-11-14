using lib_Barberia.Entidades;
using Lib_Barberia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_horarios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesAplicacion _ClientesAplicacion;

        public ClientesController(IClientesAplicacion ClientesAplicacion)
        {
            _ClientesAplicacion = ClientesAplicacion;
        }

        // GET: /Clientes/Listar
        [HttpGet]
        public List<Clientes> Listar()
        {
            return _ClientesAplicacion.Listar();
        }

        // POST: /Clientes/Guardar
        [HttpPost]
        public Clientes Guardar([FromBody] Clientes entidad)
        {
            return _ClientesAplicacion.Guardar(entidad);
        }

        // PUT: /Clientes/Modificar
        [HttpPut]
        public Clientes Modificar([FromBody] Clientes entidad)
        {
            return _ClientesAplicacion.Modificar(entidad);
        }

        // DELETE: /Clientes/Borrar
        [HttpDelete]
        public Clientes Borrar([FromBody] Clientes entidad)
        {
            return _ClientesAplicacion.Borrar(entidad);
        }
    }
}