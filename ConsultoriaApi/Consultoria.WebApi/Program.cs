using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;

namespace Consultoria.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfigurationRoot configuration = GetConfiguration();

            ConfigureLog(configuration);

            try
            {
                Log.Information("Iniciando WebApi");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Erro catastrofico");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void ConfigureLog(IConfigurationRoot configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }

        private static IConfigurationRoot GetConfiguration()
        {
            string ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{ambiente}.json", optional: true)
                .Build();
            return configuration;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
