using BibliotecaAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaAPI.Interfaces
{
    public interface IAutorService
    {
        Task<IEnumerable<AutorDTO>> GetAllAutores();
        Task<AutorDTO> GetAutorById(int id);
        Task<AutorDTO> CreateAutor(AutorDTO autorDto);
        Task UpdateAutor(int id, AutorDTO autorDto);
        Task DeleteAutor(int id);
        Task<IEnumerable<LivroDetalhesDTO>> GetLivrosByAutor(int autorId);
    }
}