using API_P1700.DTOs;
using API_P1700.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_P1700.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TiendasController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        // Constructor del controlador que recibe una unidad de trabajo y un objeto IMapper de AutoMapper
        public TiendasController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtiene todas las tiendas.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiendaDto>>> GetEmpleados()
        {
            var Tiendas = await _unitOfWork.Tiendas.GetTiendasAsync();

            var TiendasDto = _mapper.Map<List<TiendaDto>>(Tiendas);
            return TiendasDto;
        }
    }
}
