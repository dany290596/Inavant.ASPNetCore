using Empresa.Proyecto.Core.Entities;
using Empresa.Proyecto.Core.Interfaces;
using Empresa.Proyecto.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Empresa.Proyecto.Infra.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyProjectContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DBConnection"))
            );

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAsyncRepository<SimpleEntity>, EFRepository<SimpleEntity>>();
            services.AddScoped<IAsyncRepository<ComplexEntity>, EFRepository<ComplexEntity>>();

            return services;
        }
    }
}