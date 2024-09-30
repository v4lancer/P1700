using FE_P1700.RestAPIs;
using Microsoft.AspNetCore.Mvc;

namespace FE_P1700.Controllers
{
    public class PerfilesController : Controller
    {
        private readonly PerfilesAPI perfilesAPI;

        public PerfilesController(PerfilesAPI perfilesApi)
        {
            perfilesAPI = perfilesApi;
        }


        public IActionResult Index()
        {
            return View();
        }
        

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            var res = await perfilesAPI.GetPerfilesAsync();

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
