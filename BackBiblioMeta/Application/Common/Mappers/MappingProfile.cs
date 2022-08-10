
using Application.ViewModels;
using AutoMapper;
using Domain;

namespace Application.Common.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, ResponseUsuarioDto>();
            CreateMap<Libro, ResponseLibroDto>();
        }
    }
}
