using Consultoria.Manager.Validator;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Consultoria.WebApi.Configuration
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .AddFluentValidation(p =>
                {
                    p.RegisterValidatorsFromAssemblyContaining<NovoClienteValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<AlteraClienteValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<NovoEnderecoValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<NovoTelefoneValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<NovoMedicoValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<AlterarMedicoValidator>();
                });
        }
    }
}
