using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AccountController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequestModel model)
        {
            var user = await _userService.RegisterUser(model);
            return Ok(user);
        }

        [Route("Login") ]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            var userLoginResponseModel = await _userService.Login(model);
            if(userLoginResponseModel == null)
            {
                return Unauthorized();
            }
            return Ok(new { token = GenerateJwt(userLoginResponseModel) });
        }

        [Route("{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if(user == null)
            {
                return NotFound($"No User Found For Id = {id}");
            }
            return Ok(user);
        }

        private string GenerateJwt(UserLoginResponseModel user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            //get the secret key from appsettings or Azure Key/Vault
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecretKey"]));
            //select the hashing algorithm
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            //get the expiration time
            var expires = DateTime.UtcNow.AddHours(_configuration.GetValue<int>("ExpirationHours"));
            //create the JWT token with above claims and credentials and expitation time
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Issuer"],
                Audience = _configuration["Audience"],
                Subject = identityClaims,
                Expires = expires,
                SigningCredentials = credentials
            };
            var encodedJwt = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(encodedJwt);

        }

    }
}
