using AutoMapper;
using BibliotecaAPI.DTOs;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Genero, GeneroDTO>().ReverseMap();
            CreateMap<Autor, AutorDTO>().ReverseMap();
            CreateMap<Livro, LivroDTO>().ReverseMap();
            CreateMap<Livro, LivroDetalhesDTO>();
        }
    }
}
