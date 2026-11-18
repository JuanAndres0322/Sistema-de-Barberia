using lib_Barberia.Entidades;
using Microsoft.AspNetCore.Mvc;
using Web_Barberia.Acceso;
using Web_Barberia.Models;

namespace Web_Barberia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiClient _api;

        public HomeController(ApiClient api) => _api = api;

        public async Task<IActionResult> Index()
        {
            var vm = new InicioVM { Direccion = _api.Direccion };
            try
            {
                var barberos = await _api.ListarAsync<Barberos>("Barberos");
                vm.Conectada = true;
                vm.Mensaje = $"Conectado a la API en {vm.Direccion}.";
            }
            catch (ApiException ex)
            {
                vm.Mensaje = ex.Message;
            }
            return View(vm);
        }

        public IActionResult Error() => View();
    }
}
