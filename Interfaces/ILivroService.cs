using BibliotecaAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaAPI.Interfaces
{
    public interface ILivroService
    {
        Task<IEnumerable<LivroDetalhesDTO>> GetAllLivros();
        Task<LivroDetalhesDTO> GetLivroById(int id);
        Task<LivroDTO> CreateLivro(LivroDTO livroDto);
        Task UpdateLivro(int id, LivroDTO livroDto);
        Task DeleteLivro(int id);
        Task<IEnumerable<LivroDetalhesDTO>> GetLivrosByGenero(int generoId);
        Task<IEnumerable<LivroDetalhesDTO>> GetLivrosByAutor(int autorId);
    }
}