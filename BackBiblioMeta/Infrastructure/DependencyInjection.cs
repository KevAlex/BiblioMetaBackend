using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Postgresql config
            //services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationDbContext>(options =>
            //{
            //    options.UseNpgsql(configuration.GetConnectionString("WebApiDb"));
            //});

            // InMemory Db
            services.AddDbContext<ApplicationDbContext>((options) => options.UseInMemoryDatabase("TestDb"));
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            return services;
        }
    }
}
