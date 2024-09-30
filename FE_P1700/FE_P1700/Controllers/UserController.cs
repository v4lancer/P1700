using FE_P1700.RestAPIs;
using FE_P1700.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ControlGastosFE.Controllers
{
    public class UserController : Controller
    {
        private readonly UserAPI userAPI;

        public UserController(UserAPI userApi)
        {
            userAPI = userApi;
        }


        public IActionResult Autenticar()
        {
            return View();
        }
        

        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody] LoginDto Modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = await userAPI.AutenticarAsync(Modelo);

            return res != null ? 
                StatusCode(StatusCodes.Status200OK, res) : 
                StatusCode(StatusCodes.Status400BadRequest, res);

        }

        
        [HttpPost]
        public async Task<IActionResult> Registro([FromBody] RegistroDto usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = await userAPI.RegistroAsync(usuario);

            return res ?
                StatusCode(StatusCodes.Status200OK, res) :
                StatusCode(StatusCodes.Status400BadRequest, res);

        }

    }
}
