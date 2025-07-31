using BibliotecaAPI.DTOs;
using BibliotecaAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    public class GenerosController : ControllerBase
    {
        private readonly IGeneroService _generoService;
        private readonly ILogger<GenerosController> _logger;

        public GenerosController(
            IGeneroService generoService,
            ILogger<GenerosController> logger)
        {
            _generoService = generoService;
            _logger = logger;
        }

        /// <summary>
        /// Obtém todos os gêneros
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GeneroDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<IEnumerable<GeneroDTO>>> GetAll()
        {
            try
            {
                var generos = await _generoService.GetAllGeneros();
                return Ok(generos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter gêneros");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro interno");
            }
        }

        /// <summary>
        /// Obtém um gênero específico pelo ID
        /// </summary>
        /// <param name="id">ID do gênero</param>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(GeneroDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<GeneroDTO>> GetById(int id)
        {
            try
            {
                var genero = await _generoService.GetGeneroById(id);

                if (genero == null)
                {
                    return NotFound();
                }

                return Ok(genero);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter gênero com ID {Id}", id);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro interno");
            }
        }

        /// <summary>
        /// Cria um novo gênero
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(GeneroDTO), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<GeneroDTO>> Create([FromBody] GeneroDTO generoDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdGenero = await _generoService.CreateGenero(generoDto);

                return CreatedAtAction(nameof(GetById), new { id = createdGenero.Id }, createdGenero);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar gênero");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro interno");
            }
        }

        /// <summary>
        /// Atualiza um gênero existente
        /// </summary>
        /// <param name="id">ID do gênero</param>
        [HttpPut("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] GeneroDTO generoDto)
        {
            try
            {
                if (id != generoDto.Id)
                {
                    return BadRequest("ID do gênero não corresponde");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _generoService.UpdateGenero(id, generoDto);

                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar gênero com ID {Id}", id);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro interno");
            }
        }

        /// <summary>
        /// Remove um gênero
        /// </summary>
        /// <param name="id">ID do gênero</param>
        [HttpDelete("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _generoService.DeleteGenero(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir gênero com ID {Id}", id);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro interno");
            }
        }
    }
}