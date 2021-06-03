using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MySensors.ApplicationCore.Constants;

namespace MySensors.Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.USERS));
            await roleManager.CreateAsync(new IdentityRole(Roles.PREMIUMUSERS));

            /*var defaultUser = new ApplicationUser { UserName = "3dvlad@test.com", Email = "3dvlad@test.com", FirstName = "Ivan", LastName = "Ivanov"};
            await userManager.CreateAsync(defaultUser, AuthorizationConstants.DEFAULT_PASSWORD);
            await userManager.AddToRoleAsync(defaultUser, Roles.USERS);*/
        }
    }
}