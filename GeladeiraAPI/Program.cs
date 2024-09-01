using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repository.Models;

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

            builder.Services.AddDbContext<GELADEIRAContext>(options => {
            options.UseSqlServer("Server=LAPTOP-UC5IQEQ6;Database=GELADEIRA;Uid=sa;Pwd=123;Trusted_Connection=True;TrustServerCertificate=True;");
                });

            var app = builder.Build();

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