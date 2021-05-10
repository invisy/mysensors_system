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
            services.AddDbContext<MySensorsAppContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<MySensorsAppContext>();

            services.AddScoped<ITokenClaimsService, IdentityTokenClaimService>();

            return services;
        }
    }
}