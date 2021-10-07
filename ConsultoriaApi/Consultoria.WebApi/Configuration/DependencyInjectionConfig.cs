using Consultoria.Data.Repository;
using Consultoria.Manager.Implemantation;
using Consultoria.Manager.Interfaces;
using Consultoria.Manager.Interfaces.Manager;
using Consultoria.Manager.Interfaces.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Consultoria.WebApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteManager, ClienteManager>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IMedicoManager, MedicoManager>();
            services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioManager, UsuarioManager>();
        }
    }
}
