
using Api.CrossCutting.MappingsDTO;
using Api.Data.Context;
using Api.Data.Repository.Generic;
using Api.Service.AuthorService;
using API.Domain.Interfaces.Repositorys;
using API.Domain.Interfaces.Services.Author;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.         
            builder.Services.AddDbContext<MyContext>(options => options.UseSqlServer("server=.\\SQLEXPRESS2017;Initial Catalog=ApiBiblioteca;MultipleActiveResultSets=true;TrustServerCertificate=True;User ID=sa;Password=admin123;")); 

            builder.Services.AddScoped<IAuthorService, AuthorService>();
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoProfileToEntity());
            });

            IMapper mapper = config.CreateMapper();
            builder.Services.AddSingleton(mapper);


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            var urlClientCors = "http://localhost:4200";

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader().WithOrigins(urlClientCors));

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}