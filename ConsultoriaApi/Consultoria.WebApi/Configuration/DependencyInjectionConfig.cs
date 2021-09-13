using Consultoria.Data.Repository;
using Consultoria.Manager.Implemantation;
using Consultoria.Manager.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Consultoria.WebApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void UseDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteManager, ClienteManager>();
        }
    }
}
