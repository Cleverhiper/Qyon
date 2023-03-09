using QyonAdventureWorks.Domain.Interfaces;
using QyonAdventureWorks.Infra.Context;
using QyonAdventureWorks.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace QyonAdventureWorks.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesInfra(this IServiceCollection services,
           IConfiguration configuration)
        {            
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICompetidorRepository, CompetidorRepository>();
            services.AddTransient<IPistaCorridaRepository, PistaCorridaRepository>();
            services.AddTransient<IHistoricoCorridaRepository, HistoricoCorridaRepository>();


            services.AddDbContext<QylonDbContext>(opt => opt
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}