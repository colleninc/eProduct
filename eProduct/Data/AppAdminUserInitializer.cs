using api.eProduct.Data.Base;
using eProduct.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.eProduct.Data
{
    public class AppAdminUserInitializer
    {
        public static async Task SeedApp_AdminUserAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                if (!await roleManager.RoleExistsAsync(UserRoles.ApiTokenUser))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.ApiTokenUser));
                //Check and Add admin user
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "Admin@gmain.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Administrator",
                        UserName = "Admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    var result = await userManager.CreateAsync(newAdminUser, "AdminProd1@");
                    if (result.Succeeded)//ensures that the user is created before adding role
                    {
                        await userManager.RemoveFromRoleAsync(newAdminUser, UserRoles.Admin);
                        await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                    }
                    
                }

                string appUserEmail = "apiuser@api_eproduct.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "API Application User",
                        UserName = "API-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "APIuser@1234");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
