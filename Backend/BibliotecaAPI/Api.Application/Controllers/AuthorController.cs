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
        public async Task<IActionResult> AddAuthor([FromBody]AuthorEntity author)
        {
            return Ok(await _authorService.AddAuthor(author));          
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            return Ok(await _authorService.GetAllAuthors());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(Guid id)
        {
           
                var author = await _authorService.GetByIdAuthor(id);
                if (author == null)
                {
                    return NotFound($"Autor com ID {id} não encontrado.");
                }
                return Ok(author);          
        }

        [HttpPut("{id}")]
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
