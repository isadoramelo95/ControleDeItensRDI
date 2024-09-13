using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Repository.Context;
using Repository.Interfaces;
using Repository.RepositoriesClasses;
using Services;
using Services.DIP;
using Services.Interfaces;

namespace GeladeiraAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the containerList.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            Initializer.Configure(builder.Services,
                         builder.Configuration.GetConnectionString("DefaultConnection"));
            var app = builder.Build();

            //builder.Services.AddScoped<IServices<Item>, GeladeiraService>();
            //builder.Services.AddScoped<IRepository<Item>, GeladeiraRepository>();

            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            //// Iniciar o app
            // app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}