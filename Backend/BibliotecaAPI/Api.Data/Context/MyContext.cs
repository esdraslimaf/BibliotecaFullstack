using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Context
{
    public class MyContext:DbContext

    {

        public MyContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<AuthorEntity> Authors { get; set; }


    }
}
