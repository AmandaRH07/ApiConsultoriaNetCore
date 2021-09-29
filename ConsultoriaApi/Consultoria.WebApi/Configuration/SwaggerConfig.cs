using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Consultoria.WebApi.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Consultoria Api",
                    Version = "v1",
                    Description = "API de aplicação de consultoria.",
                    Contact = new OpenApiContact
                    {
                        Name = "Amanda Rafaela Hass",
                        Email = "amandahass02@gmail.com",
                        Url = new Uri("https://github.com/AmandaRH07")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "OSD",
                        Url = new Uri("https://opensource.org/osd")
                    },
                    TermsOfService = new Uri("https://opensource.org/osd")
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                xmlPath = Path.Combine(AppContext.BaseDirectory, "Consultoria.Core.Shared.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }
        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "Consultoria Api V1");
            });
        }
    }
}
