using API_P1700.Interfaces;
using API_P1700.Utilidades;
using API_P1700.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_P1700.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        // Constructor del controlador que recibe una unidad de trabajo y un objeto IMapper de AutoMapper
        public UserController(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }


        /// <summary>
        /// Registra un nuevo usuario
        /// </summary>
        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar(RegistroDto usuario)
        {
            var response = await _unitOfWork.Usuarios.Registrar(usuario);

            if (response != null && response.SpResponse == 1)
            {
                return CreatedAtAction(nameof(Registrar), new { cedula = usuario.Cedula }, usuario); // 201 Created
            }

            return BadRequest(usuario); // 400 Bad Request

        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        [HttpPost("Autenticar")]
        public async Task<IActionResult> Autenticar(LoginDto loginDto)
        {
            // Verifica las credenciales del usuario y obten su información
            var loginResult = await AuthenticarUsuario(loginDto.Cedula, loginDto.Contrasenia);

            if (loginResult == null)
                return BadRequest(); // 400 Bad Request

            return Ok(loginResult); // 200 Success
        }


        /// <summary>
        /// Autenticación de usuario
        /// </summary>
        /// <param name="cedula"></param>
        /// <param name="contrasenia"></param>
        /// <returns></returns>
        private async Task<LoginResultDto> AuthenticarUsuario(string cedula, string contrasenia)
        {
            Cifrado cifrado = new Cifrado();
            bool valido = false;
            LoginResultDto result = new LoginResultDto();

            var usuarios = await _unitOfWork.Usuarios.GetUsuariosAsync();

            var usuarioCoincide = usuarios.FirstOrDefault(u => u.Cedula == cedula);

            if (usuarioCoincide != null) valido = cifrado.Desencriptar(contrasenia, usuarioCoincide.Contrasenia);

            if (valido)
            {
                var empleado = await ObtenerEmpleadoDeUsuario(usuarioCoincide.IdUsuario);

                if (empleado != null) {
                    result.IdPerfil = usuarioCoincide.IdPerfil;
                    result.Nombre = empleado.Nombre;
                    return result;
                }
            }
            
            return null;
        }


        /// <summary>
        /// Obtener Empleado de Usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        private async Task<EmpleadoDto> ObtenerEmpleadoDeUsuario(int idUsuario)
        {
            var empleados = await _unitOfWork.Empleados.GetEmpleadosAsync();
            var empleadoDto = _mapper.Map<EmpleadoDto>(empleados.Where(x => x.IdUsuario == idUsuario).FirstOrDefault());

            if(empleadoDto == null) return null;

            return empleadoDto;
        }

    }
}
