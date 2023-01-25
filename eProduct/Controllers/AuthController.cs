using api.eProduct.Data.Dto;
using eProduct.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace api.eProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, 
            RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("GetToken")]
        public async Task<TokenResponse> GetToken([FromBody] LoginDto model)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(model.EmailAddress, model.Password, false, false);
                TokenResponse tokenResponse;
                if (result.Succeeded)
                {
                    var appUser = _userManager.Users.SingleOrDefault(r => r.UserName == model.EmailAddress);
                    var jwtToken = await GenerateJwtToken(model.EmailAddress, appUser);
                    
                    return tokenResponse = new TokenResponse
                    {
                        Token = jwtToken == null ? string.Empty : jwtToken.ToString()
                    };
                }
                else
                {
                   return null;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("INVALID_LOGIN_ATTEMPT: " + ex.Message);
            }
        }

        private async Task<object> GenerateJwtToken(string email, ApplicationUser user)
        {
            try
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"].ToString()));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var JwtExpireDays = _configuration["JwtExpireDays"].ToString();
                var expires = DateTime.Now.AddDays(Convert.ToDouble(JwtExpireDays));

                var token = new JwtSecurityToken
                (
                    _configuration["JwtIssuer"].ToString(),
                    _configuration["JwtIssuer"].ToString(),
                    claims,
                    expires: expires,
                    signingCredentials: creds
                );
                
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception x)
            {
                throw new Exception("GenerateJwtToken ERROR: " + x);
            }
        }
    }

    public class TokenResponse
    {
        public string Token { get; set; }
    }
}
