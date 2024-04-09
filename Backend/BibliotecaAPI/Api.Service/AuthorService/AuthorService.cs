using API.Domain.Entities;
using API.Domain.Interfaces.Repositorys;
using API.Domain.Interfaces.Services.Author;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.AuthorService
{
    public class AuthorService:IAuthorService
    {
        private readonly IBaseRepository<AuthorEntity> _repo;
        public AuthorService(IBaseRepository<AuthorEntity> repo)
        {
            _repo = repo;
        }

        public async Task<AuthorEntity> AddAuthor(AuthorEntity entity)
        {
            try
            {
                return await _repo.Add(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteAuthor(Guid id)
        {
            
            try
            {
                var entity = await _repo.GetById(id);
                if (entity != null)
                {
                   return await _repo.Delete(entity);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<AuthorEntity>> GetAllAuthors()
        {
            try
            {
                return await _repo.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AuthorEntity> GetByIdAuthor(Guid id)
        {
            try
            {
                return await _repo.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AuthorEntity> UpdateAuthor(AuthorEntity entity)
        {
            try
            {
                var existingEntity = await _repo.GetById(entity.Id);

                existingEntity.UpdateAt = DateTime.Now;
                existingEntity.Password = entity.Password;
                existingEntity.Email = entity.Email;
                existingEntity.Name = entity.Name;     

                return await _repo.Update(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
