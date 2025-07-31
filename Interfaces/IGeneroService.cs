using BibliotecaAPI.DTOs;

namespace BibliotecaAPI.Interfaces
{
    public interface IGeneroService
    {
        Task<IEnumerable<GeneroDTO>> GetAllGeneros();
        Task<GeneroDTO> GetGeneroById(int id);
        Task<GeneroDTO> CreateGenero(GeneroDTO generoDto);
        Task UpdateGenero(int id, GeneroDTO generoDto);
        Task DeleteGenero(int id);
    }
}
