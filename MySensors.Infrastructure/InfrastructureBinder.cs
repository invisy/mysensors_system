using MySensors.Infrastructure.Data;
using MySensors.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySensors.ApplicationCore.Interfaces;

namespace MySensors.Infrastructure
{
    public static class InfrastructureBinder
    {
        public static IServiceCollection BindInfrastructureLayer(this IServiceCollection services, string connectionString)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
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