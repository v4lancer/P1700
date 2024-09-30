using FE_P1700.DTOs;
using FE_P1700.RestAPIs;
using Microsoft.AspNetCore.Mvc;

namespace FE_P1700.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly EmpleadosAPI empleadosAPI;

        public EmpleadosController(EmpleadosAPI empleadosApi)
        {
            empleadosAPI = empleadosApi;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            var res = await empleadosAPI.GetEmpleadosAsync();

            // Crear un objeto anónimo para la respuesta JSON
            var result = new
            {
                recordsTotal = res.Count,
                recordsFiltered = res.Count,
                data = res
            };

            return StatusCode(StatusCodes.Status200OK, result);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmpleadoDto Modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await empleadosAPI.PostEmpleadoAsync(Modelo);

            return result ?
                StatusCode(StatusCodes.Status200OK, new { valor = result }) :
                StatusCode(StatusCodes.Status500InternalServerError, new { valor = result });
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EmpleadoDto Modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             
            var result = await empleadosAPI.PutEmpleadoAsync(Modelo);

            return result ?
                StatusCode(StatusCodes.Status200OK, new { valor = result }) :
                StatusCode(StatusCodes.Status500InternalServerError, new { valor = result });

        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] int Codigo)
        {
            var result = await empleadosAPI.DeleteEmpleadoAsync(Codigo);

            return result ?
                StatusCode(StatusCodes.Status200OK, new { valor = result }) :
                StatusCode(StatusCodes.Status500InternalServerError, new { valor = result });
        }

    }
}
