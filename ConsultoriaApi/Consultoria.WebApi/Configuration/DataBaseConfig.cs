using Consultoria.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Consultoria.WebApi.Configuration
{
    public static class DataBaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ConsultoriaDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConsultoriaConnection")));
        }

        public static void USeDatabaseConfiguration(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<ConsultoriaDbContext>();
            context.Database.Migrate();
            context.Database.EnsureCreated();
        }
    }
}
