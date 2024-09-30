using API_P1700.DTOs;
using API_P1700.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_P1700.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        // Constructor del controlador que recibe una unidad de trabajo y un objeto IMapper de AutoMapper
        public PerfilesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtiene todos los Perfiles.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PerfileDto>>> GetPerfiles()
        {
            var Perfiles = await _unitOfWork.Perfiles.GetPerfilesAsync();

            var PerfilesDto = _mapper.Map<List<PerfileDto>>(Perfiles);
            return PerfilesDto;
        }
    }
}
