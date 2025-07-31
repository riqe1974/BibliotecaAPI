using BibliotecaAPI.Data;
using BibliotecaAPI.DTOs;
using BibliotecaAPI.Interfaces;
using BibliotecaAPI.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace BibliotecaAPI.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GeneroService> _logger;

        public GeneroService(ApplicationDbContext context, IMapper mapper, ILogger<GeneroService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<GeneroDTO>> GetAllGeneros()
        {
            try
            {
                var generos = await _context.Generos
                    .AsNoTracking()
                    .ToListAsync();

                return _mapper.Map<IEnumerable<GeneroDTO>>(generos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todos os gêneros");
                throw;
            }
        }

        public async Task<GeneroDTO> GetGeneroById(int id)
        {
            try
            {
                var genero = await _context.Generos
                    .AsNoTracking()
                    .FirstOrDefaultAsync(g => g.Id == id);

                if (genero == null)
                {
                    _logger.LogWarning("Gênero com ID {Id} não encontrado", id);
                    return null;
                }

                return _mapper.Map<GeneroDTO>(genero);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter gênero com ID {Id}", id);
                throw;
            }
        }

        public async Task<GeneroDTO> CreateGenero(GeneroDTO generoDto)
        {
            try
            {
                var genero = _mapper.Map<Genero>(generoDto);

                _context.Generos.Add(genero);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Gênero criado com ID {Id}", genero.Id);

                return _mapper.Map<GeneroDTO>(genero);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar gênero");
                throw;
            }
        }

        public async Task UpdateGenero(int id, GeneroDTO generoDto)
        {
            try
            {
                if (id != generoDto.Id)
                {
                    _logger.LogWarning("IDs não correspondem: {Id} vs {DtoId}", id, generoDto.Id);
                    throw new ArgumentException("IDs não correspondem");
                }

                var generoExistente = await _context.Generos.FindAsync(id);
                if (generoExistente == null)
                {
                    _logger.LogWarning("Gênero com ID {Id} não encontrado para atualização", id);
                    throw new KeyNotFoundException("Gênero não encontrado");
                }

                _mapper.Map(generoDto, generoExistente);

                _context.Generos.Update(generoExistente);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Gênero com ID {Id} atualizado", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar gênero com ID {Id}", id);
                throw;
            }
        }

        public async Task DeleteGenero(int id)
        {
            try
            {
                var genero = await _context.Generos
                    .Include(g => g.Livros)
                    .FirstOrDefaultAsync(g => g.Id == id);

                if (genero == null)
                {
                    _logger.LogWarning("Gênero com ID {Id} não encontrado para exclusão", id);
                    throw new KeyNotFoundException("Gênero não encontrado");
                }

                if (genero.Livros?.Any() == true)
                {
                    _logger.LogWarning("Tentativa de excluir gênero com ID {Id} que possui livros associados", id);
                    throw new InvalidOperationException("Não é possível excluir gênero com livros associados");
                }

                _context.Generos.Remove(genero);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Gênero com ID {Id} excluído", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir gênero com ID {Id}", id);
                throw;
            }
        }
    }
}