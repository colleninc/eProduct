using api.eProduct.Data.Base;
using api.eProduct.Data.Dto;
using eProduct.Data;
using eProduct.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.eProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpPost]
        [Route("AuthenticateUser")]
        [Authorize]
        public async Task<AuthUser> AuthenticateUser([FromBody] LoginDto login)
        {
            try
            {

                if (login is null)
                {
                    return new AuthUser() { UserId = Guid.Empty };
                }

                var user = await _userManager.FindByEmailAsync(login.EmailAddress);
                if (user == null) return new AuthUser() { UserId = Guid.Empty };

                var result = await _signInManager.PasswordSignInAsync(user.UserName, login.Password, false, false);
                    if (result.Succeeded)
                    {
                        //ApplicationUser appUser = _userManager.Users.SingleOrDefault(r => r.UserName == user.UserName);
                        IList<string> userRoles = await _userManager.GetRolesAsync(user).ConfigureAwait(true);
                        
                        AuthUser log_User = new AuthUser
                        {
                            UserId = Guid.Parse(user.Id),
                            DisplayName = user.FullName,
                            Email = user.Email,
                            
                            //RoleId = role.Id,
                            UserRole = userRoles.Count >0 ? userRoles[0].ToString() : "",

                        };
                        return log_User;
                        //return Ok(log_User);
                    }
                    else
                        return new AuthUser() { UserId = Guid.Empty };
                               
                
            }
            catch (Exception ex)
            {
                throw new ApplicationException("INVALID_LOGIN_ATTEMPT: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("Register")]
        [Authorize]
        public async Task<IActionResult> Register([FromBody] RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                return BadRequest("This email address is already in use. Please use a different Email.");
                
            }

            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            return Ok("RegisterCompleted");
        }
    }
}
