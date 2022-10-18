﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MasterServicesFZ.Application.Contracts.Persistence;
using MasterServicesFZ.Infrastructure.Persistence;
using MasterServicesFZ.Infrastructure.Repositories;

namespace MasterServicesFZ.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PostgresDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("PostgreConnection"))
            );
            services.AddDbContext<SqlDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlConnection"))
            );

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IVehicleBrandRepository, BrandRepository>();
            services.AddScoped<IIdentificationTypeRepository, IdentificationTypeRepository>();

            return services;
        }
    }
}
