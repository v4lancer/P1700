using Microsoft.AspNetCore.Mvc;
using API_P1700.DTOs;
using AutoMapper;
using API_P1700.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace API_P1700.Controllers
{
    // Especifica que este controlador responde a las solicitudes en la ruta "/api/[controller]"
    // donde "[controller]" se sustituye por el nombre de la clase sin "Controller" al final

    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        // Constructor del controlador que recibe una unidad de trabajo y un objeto IMapper de AutoMapper
        public EmpleadosController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        
        /// <summary>
        /// Obtiene todos los Empleados.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadoDto>>> GetEmpleados()
        {
            var Empleados = await _unitOfWork.Empleados.GetEmpleadosAsync();

            var EmpleadosDto = _mapper.Map<List<EmpleadoDto>>(Empleados);
            return EmpleadosDto;
        }


        /// <summary>
        /// Obtiene un Empleado por su ID.
        /// </summary>
        /// <param name="id">ID del Empleado.</param>
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleadoDto>> GetEmpleado(int id)
        {
            var Empleados = await _unitOfWork.Empleados.GetEmpleadoById(id);

            var EmpleadosDto = _mapper.Map<EmpleadoDto>(Empleados);
            return EmpleadosDto;
        }

        /// <summary>
        /// Crea un nuevo Empleado.
        /// </summary>
        /// <param name="EmpleadosDto">Datos del nuevo Empleado.</param>
        [HttpPost]
        public async Task<ActionResult<EmpleadoDto>> PostEmpleado(EmpleadoDto EmpleadosDto)
        {
            // Método para crear un nuevo Empleado
            // Responde a las solicitudes POST en la ruta base del controlador ("/api/Empleado")

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _unitOfWork.Empleados.MantenimientoEmpleados(EmpleadosDto, 0);

            if (response != null && response.SpResponse == 1)
                return Ok();
            else
                return NotFound();
        }

        /// <summary>
        /// Actualiza un Empleado existente.
        /// </summary>
        /// <param name="EmpleadosDto">Datos del Empleado actualizados.</param>
        [HttpPut]
        public async Task<IActionResult> PutEmpleado(EmpleadoDto EmpleadosDto)
        {
            // Método para actualizar un Empleado
            // Responde a las solicitudes PUT en la ruta con el ID del Empleado ("/api/Empleado/5")

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _unitOfWork.Empleados.MantenimientoEmpleados(EmpleadosDto, 1);

            if (response != null && response.SpResponse == 1)
                return Ok();
            else
                return NotFound();
        }

        /// <summary>
        /// Elimina un Empleado por su ID.
        /// </summary>
        /// <param name="id">ID del Empleado a eliminar.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            // Método para eliminar un Empleado por su ID
            // Responde a las solicitudes DELETE en la ruta con el ID del Empleado ("/api/Empleado/5")

            EmpleadoDto EmpleadosDto = new EmpleadoDto { IdEmpleado = id, Nombre = "", Telefono = "", Salario = 0, IdSupervisor = 0, IdTienda = 0, IdUsuario = 0, EsSupervisor = false};

            var response = await _unitOfWork.Empleados.MantenimientoEmpleados(EmpleadosDto, 2);

            if (response != null && response.SpResponse == 1)
                return Ok();
            else
                return NotFound();
        }
    }
}