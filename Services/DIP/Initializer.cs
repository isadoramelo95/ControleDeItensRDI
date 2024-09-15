using GeladeiraCodeRDIVersity;
using GeladeiraRepository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using GeladeiraRepository.Interfaces;
using GeladeiraRepository.RepositoryClass;
using Services.ServiceClass;

namespace Services.DIP
{
    public class Initializer
    {
        public static void Configure(IServiceCollection services, string connection)
        {
            services.AddDbContext<GeladeiraContext>(options => options.UseSqlServer(connection));

            services.AddScoped(typeof(IGeladeiraRepository<Item>), typeof(GeladeiraRepositoryClass));
            services.AddScoped(typeof(IGeladeiraService<Item>), typeof(GeladeiraService));
        }
    }
}
