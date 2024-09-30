using FE_P1700.RestAPIs;
using Microsoft.AspNetCore.Mvc;

namespace FE_P1700.Controllers
{
    public class TiendasController : Controller
    {
        private readonly TiendasAPI tiendasAPI;

        public TiendasController(TiendasAPI tiendasApi)
        {
            tiendasAPI = tiendasApi;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            var res = await tiendasAPI.GetTiendasAsync();

            // Crear un objeto anónimo para la respuesta JSON
            var result = new
            {
                recordsTotal = res.Count,
                recordsFiltered = res.Count,
                data = res
            };

            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
