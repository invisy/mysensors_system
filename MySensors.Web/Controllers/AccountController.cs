using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MySensors.ApplicationCore.Constants;
using MySensors.ApplicationCore.Interfaces;
using MySensors.Infrastructure.Identity;
using MySensors.Web.ViewModels;

namespace MySensors.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenClaimsService _tokenClaimsService;
        
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenClaimsService tokenClaimsService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenClaimsService = tokenClaimsService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest credentials)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid input");
            
            var result = await _signInManager.PasswordSignInAsync(credentials.Login, credentials.Password, false, false);

            LoginResponse response = new LoginResponse();
            
            if (result.Succeeded)
                response.Token = await _tokenClaimsService.GetTokenAsync(credentials.Login);
            else
                return Unauthorized("Invalid login or password");

            return Ok(response);
        }
        
        [HttpPost("register")]
        public async Task<ActionResult<LoginResponse>> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid input");
            
            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                FirstName = request.Name,
                LastName = request.Surname
            };
            
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                return UnprocessableEntity(result.Errors.FirstOrDefault().Description);

            await _userManager.AddToRoleAsync(user, Roles.USERS);

            return Ok();
        }
    }
}