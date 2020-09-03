using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Handlers;
using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Interfaces;
using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Uow;
using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Repositories;
using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Configuration
{
    public static class BootstrapInjection
    {
        /// <summary>
        /// Metodo que injeta as dependências e retorna a implementação da Interface desejada
        /// </summary>
        /// <returns></returns>
        public static IServiceProvider GetServiceCollection()
        {
            var dbLocation = "Data Source=ArrayValues.db";

            IServiceCollection services = new ServiceCollection();

            services.AddDbContext<DataContext>(options =>
                options.UseSqlite(dbLocation)
            );

            services.AddSingleton<IQueryRepository>(x => new QueryRepository(dbLocation));
            services.AddScoped<IUnitDataContext, UnitDataContext>();
            services.AddScoped<IIndiceRepository, IndiceRepository>();
            services.AddScoped<IValuesInArrayRepository, ValuesInArrayRepository>();
            services.AddScoped<ISeedValuesInArrayHandler, SeedValuesInArrayHandler>();
            services.AddScoped<ICalcAdjacentValueHandler, CalcAdjacentValueHandler>();

            return services.BuildServiceProvider();
        }
    }
}
