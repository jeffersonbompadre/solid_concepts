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
        public static IServiceProvider GetServiceCollection()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddDbContext<DataContext>(options =>
                options.UseSqlite("Data Source=ArrayValues.db")
            );

            services.AddScoped<IUnitDataContext, UnitDataContext>();
            services.AddScoped<IIndiceRepository, IndiceRepository>();
            services.AddScoped<IValuesInArrayRepository, ValuesInArrayRepository>();
            services.AddScoped<ISeedValuesInArrayHandler, SeedValuesInArrayHandler>();
            services.AddScoped<ICalcAdjacentValueHandler, CalcAdjacentValueHandler>();

            return services.BuildServiceProvider();
        }
    }
}
