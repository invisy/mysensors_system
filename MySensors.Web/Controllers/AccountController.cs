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
using MySensors.Web.ViewModels;

namespace MySensors.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenClaimsService _tokenClaimsService;
        
        public AccountController(SignInManager<ApplicationUser> signInManager, ITokenClaimsService tokenClaimsService)
        {
            _signInManager = signInManager;
            _tokenClaimsService = tokenClaimsService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest credentials)
        {
            if (credentials.Login == null ||  credentials.Password == null)
                return BadRequest(new { error = "Invalid input" });
            
            var result = await _signInManager.PasswordSignInAsync(credentials.Login, credentials.Password, false, false);

            LoginResponse response = new LoginResponse();
            
            if (result.Succeeded)
                response.Token = await _tokenClaimsService.GetTokenAsync(credentials.Login);
            else
                return BadRequest(new { error = "Invalid login or password" });

            return Ok(response);
        }
    }
}