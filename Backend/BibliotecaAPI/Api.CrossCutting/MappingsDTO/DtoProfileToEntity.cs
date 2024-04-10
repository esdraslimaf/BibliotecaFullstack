using API.Domain.Dtos.Author;
using API.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CrossCutting.MappingsDTO
{
    public class DtoProfileToEntity:Profile
    {
        public DtoProfileToEntity()
        {
            //Author
            CreateMap<AuthorDtoCreate, AuthorEntity>().ReverseMap();
        }
    }
}
