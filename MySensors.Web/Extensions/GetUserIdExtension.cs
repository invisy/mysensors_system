using System.Linq;
using System.Security.Claims;

namespace MySensors.Web.Extensions
{
    public static class GetUserIdExtension
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            return user.Claims.First(i => i.Type == "nameid").Value;
        }
    }
}