﻿using MySensors.Infrastructure.Data;
using MySensors.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySensors.ApplicationCore.Entities;
using MySensors.ApplicationCore.Interfaces;

namespace MySensors.Infrastructure
{
    public static class InfrastructureBinder
    {
        public static IServiceCollection BindInfrastructureLayer(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IAsyncRepository<int, Sensor>, GenericRepository<int, Sensor>>();
            services.AddScoped<IAsyncRepository<int, SensorParameter>, GenericRepository<int, SensorParameter>>();
            services.AddScoped<IAsyncRepository<int, SensorParameterValue>, GenericRepository<int, SensorParameterValue>>();
            services.AddScoped<IAsyncRepository<int, SensorUpdateTime>, GenericRepository<int, SensorUpdateTime>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            
            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
                {
                    config.SignIn.RequireConfirmedEmail = false;
                })
                .AddDefaultUI()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();
            
            services.AddDbContext<MySensorsAppContext>(options =>
                options.UseInMemoryDatabase(databaseName: "Test"));

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "TestIdentity"));
            

            services.AddScoped<ITokenClaimsService, IdentityTokenClaimService>();

            return services;
        }
    }
}