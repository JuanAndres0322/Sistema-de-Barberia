using lib_Barberia.Entidades;
using Lib_Barberia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_horarios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HorariosDisponibilidadController : ControllerBase
    {
        private readonly IHorariosDisponibilidadAplicacion _HorariosDisponibilidadAplicacion;

        public HorariosDisponibilidadController(IHorariosDisponibilidadAplicacion HorariosDisponibilidadAplicacion)
        {
            _HorariosDisponibilidadAplicacion = HorariosDisponibilidadAplicacion;
        }

        // GET: /HorariosDisponibilidad/Listar
        [HttpGet]
        public List<HorariosDisponibilidad> Listar()
        {
            return _HorariosDisponibilidadAplicacion.Listar();
        }

        // POST: /HorariosDisponibilidad/Guardar
        [HttpPost]
        public HorariosDisponibilidad Guardar([FromBody] HorariosDisponibilidad entidad)
        {
            return _HorariosDisponibilidadAplicacion.Guardar(entidad);
        }

        // PUT: /HorariosDisponibilidad/Modificar
        [HttpPut]
        public HorariosDisponibilidad Modificar([FromBody] HorariosDisponibilidad entidad)
        {
            return _HorariosDisponibilidadAplicacion.Modificar(entidad);
        }

        // DELETE: /HorariosDisponibilidad/Borrar
        [HttpDelete]
        public HorariosDisponibilidad Borrar([FromBody] HorariosDisponibilidad entidad)
        {
            return _HorariosDisponibilidadAplicacion.Borrar(entidad);
        }
    }
}