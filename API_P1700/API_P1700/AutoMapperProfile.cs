using API_P1700.DTOs;
using API_P1700.Models;
using AutoMapper;

namespace API_P1700
{
    // Definición de una clase que hereda de Profile, que es una clase de AutoMapper para configuración de mapeos
    public class AutoMapperProfile : Profile
    {
        // Constructor de la clase
        public AutoMapperProfile()
        {
            // Dentro del constructor se definen los mapeos entre clases

            // CreateMap<TOrigen, TDestino>() define un mapeo entre la clase TOrigen y la clase TDestino
            // En este caso, se está mapeando la clase Empleado a la clase EmpleadoDto, y viceversa (ReverseMap)
            CreateMap<Empleado, EmpleadoDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Perfile, PerfileDto>().ReverseMap();
            CreateMap<Tienda, TiendaDto>().ReverseMap();

        }
    }

}