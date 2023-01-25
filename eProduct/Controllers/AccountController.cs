using api.eProduct.Data.Dto;
using eProduct.Data;
using eProduct.Model;
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
        public async Task<AuthUser> AuthenticateUser(LoginDto login)
        {
            try
            {

                if (login is null)
                {
                    return new AuthUser() { UserId = Guid.Empty };
                }

                var user = await _userManager.FindByEmailAsync(login.EmailAddress);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user.UserName, login.Password, false, false);
                    if (result.Succeeded)
                    {
                        ApplicationUser appUser = _userManager.Users.SingleOrDefault(r => r.UserName == user.UserName);
                        IList<string> userRoles = await _userManager.GetRolesAsync(user: appUser).ConfigureAwait(true);
                        
                        AuthUser log_User = new AuthUser
                        {
                            UserId = Guid.Parse(appUser.Id),
                            DisplayName = appUser.FullName,
                            Email = appUser.Email,
                            
                            //RoleId = role.Id,
                            UserRole = userRoles.ToString(),

                        };
                        return log_User;
                        //return Ok("SUCCESS");
                    }
                    else
                        return new AuthUser() { UserId = Guid.Empty };
                }                
                else
                {
                    return new AuthUser() { UserId = Guid.Empty };
                    //return Ok("SUCCESS");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("INVALID_LOGIN_ATTEMPT: " + ex.Message);
            }
        }
    }
}
