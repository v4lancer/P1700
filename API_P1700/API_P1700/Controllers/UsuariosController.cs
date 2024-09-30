using API_P1700.DTOs;
using API_P1700.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_P1700.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        // Constructor del controlador que recibe una unidad de trabajo y un objeto IMapper de AutoMapper
        public UsuariosController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        
        /// <summary>
        /// Obtiene todos los Usuarios.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetUsuarios()
        {
            var Usuarios = await _unitOfWork.Usuarios.GetUsuariosAsync();

            var UsuariosDto = _mapper.Map<List<UsuarioDto>>(Usuarios);
            return UsuariosDto;
        }
    }
}
