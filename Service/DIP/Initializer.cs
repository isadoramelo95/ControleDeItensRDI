using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.Context;
using Repository.RepositoriesClasses;
using Repository.Interfaces;
using Services.Interfaces;
using Services.ServicesClasses;
using Microsoft.Extensions.Configuration;

namespace Services.DIP
{
    public class Initializer
    {
        public static void Configure(IServiceCollection services, string connection)
        {
            services.AddDbContext<GeladeiraContext>(options => options.UseSqlServer(connection));

            services.AddScoped(typeof(IRepository<Item>), typeof(GeladeiraRepository));
            services.AddScoped(typeof(IServices<Item>), typeof(GeladeiraService));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}
