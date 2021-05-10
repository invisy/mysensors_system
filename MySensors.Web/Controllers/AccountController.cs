using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MySensors.ApplicationCore.Interfaces;
using MySensors.Infrastructure.Identity;

namespace MySensors.Web.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenClaimsService _tokenClaimsService;
        
        public AccountController(SignInManager<ApplicationUser> signInManager, ITokenClaimsService tokenClaimsService)
        {
            _signInManager = signInManager;
            _tokenClaimsService = tokenClaimsService;
        }

        [HttpPost("auth")]
        public async Task<IActionResult> Auth(string username, string password, bool isPersistent)
        {
            if (username == null || password == null)
                return BadRequest(new { errorText = "Invalid username or password." });
            
            var result = await _signInManager.PasswordSignInAsync(username, password, isPersistent, false);

            string token = String.Empty;
            
            if (result.Succeeded)
                token = await _tokenClaimsService.GetTokenAsync(username);

            return new EmptyResult();
        }
    }
}