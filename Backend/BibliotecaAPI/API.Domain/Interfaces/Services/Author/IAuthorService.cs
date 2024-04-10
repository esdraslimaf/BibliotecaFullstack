using API.Domain.Dtos.Author;
using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Interfaces.Services.Author
{
    public interface IAuthorService
    {
        Task<AuthorEntity> AddAuthor(AuthorDtoCreate entity);
        Task<AuthorEntity> GetByIdAuthor(Guid id);
        Task<IEnumerable<AuthorEntity>> GetAllAuthors();
        Task<AuthorEntity> UpdateAuthor(AuthorEntity entity);
        Task<bool> DeleteAuthor(Guid id);
    }
}
