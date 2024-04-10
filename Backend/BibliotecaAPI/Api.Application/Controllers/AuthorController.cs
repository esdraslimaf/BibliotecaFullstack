using API.Domain.Dtos.Author;
using API.Domain.Entities;
using API.Domain.Interfaces.Services.Author;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController:ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody]AuthorDtoCreate authorDtoCreate)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _authorService.AddAuthor(authorDtoCreate));
            }
            catch (Exception)
            {
                throw;
            }
                    
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            return Ok(await _authorService.GetAllAuthors());
        }

        [HttpGet("BuscarPorId/{id}")]
        public async Task<IActionResult> GetAuthorById(Guid id)
        {
           
                var author = await _authorService.GetByIdAuthor(id);
                if (author == null)
                {
                    return NotFound($"Autor com ID {id} não encontrado.");
                }
                return Ok(author);          
        }

        [HttpPut("Atualizar")]
        public async Task<IActionResult> UpdateAuthor([FromBody] AuthorEntity updatedAuthor)
        {
            var author = await _authorService.GetByIdAuthor(updatedAuthor.Id);
            if (author == null)
            {
                return NotFound($"Autor com ID {updatedAuthor.Id} não encontrado.");
            }

            var result = await _authorService.UpdateAuthor(updatedAuthor);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            var author = await _authorService.GetByIdAuthor(id);
            if (author == null)
            {
                return NotFound($"Autor com ID {id} não encontrado.");
            }

            var result = await _authorService.DeleteAuthor(id);
            return Ok(result);
        }

    }
}
