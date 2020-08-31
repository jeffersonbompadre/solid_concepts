using CandiateTesting.JeffersonBompadre.CDNConvert.Domain.Entities;
using CandiateTesting.JeffersonBompadre.CDNConvert.Domain.Handlers;
using CandiateTesting.JeffersonBompadre.CDNConvert.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CandiateTesting.JeffersonBompadre.CDNConvert.Domain.Configuration
{
    public static class BootstrapInjection
    {
        public static IServiceProvider GetServiceCollection()
        {
            IServiceCollection services = new ServiceCollection();

            // Realiza a injeção de dependência
            services.AddSingleton<ICDNRequest, CDNRequest>();
            services.AddSingleton<ICDNConvertStandard, CDNConvertStandard>();
            services.AddSingleton<IFileContent, FileContent>();
            services.AddScoped<ICDNConvertHandler, CDNConvertHandler>();

            return services.BuildServiceProvider();
        }
    }
}
