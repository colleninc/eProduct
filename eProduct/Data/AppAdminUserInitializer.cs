using api.eProduct.Data.Base;
using eProduct.Data;
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
        public static void InitializeProductCategories(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Product Category
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<ProductCategory>()
                    {
                        new ProductCategory()
                        {
                            Id = Guid.NewGuid(),
                            Description = "Toys"
                        },
                        new ProductCategory()
                        {
                            Id = Guid.Parse("3AEBBF07-2F89-4F2A-A95F-CAC3FB2C595F"),
                            Description = "Gaming"
                        },

                        new ProductCategory()
                        {
                            Id = Guid.NewGuid(),
                            Description = "Camping & Outdoor"
                        },
                        new ProductCategory()
                        {
                            Id = Guid.Parse("760C4F49-A2B6-40CC-BBF8-5822228E4E15"),
                            Description = "Books & Courses"
                        },
                    });
                    context.SaveChanges();
                }

                //Products
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            Id = Guid.NewGuid(),
                            ProductCategoryId = Guid.Parse("760C4F49-A2B6-40CC-BBF8-5822228E4E15"),
                            ProductName = "The English handbook and study guide",
                            Description = "A comprehensive English reference book by Beryl LutrinPaperback / Softback",
                            Quantity = 15,
                            Re_OrderLevel = 5,
                            Price = 436.00,
                            ImageURL = "https://media.takealot.com/covers_tsins/29284125/0426142dddc8bf42a35f646acd6c25d1-pdpxl.jpg"
                        },
                        new Product()
                        {
                            Id = Guid.NewGuid(),
                            ProductCategoryId = Guid.Parse("760C4F49-A2B6-40CC-BBF8-5822228E4E15"),
                            ProductName = "The Richest Man In Babylon",
                            Description = "A comprehensive English reference book by Beryl LutrinPaperback / Softback",
                            Quantity = 5,
                            Re_OrderLevel = 5,
                            Price = 125.00,
                            ImageURL = "https://media.takealot.com/covers_images/8d124aa50d734470b4a74350d72b64c5/s-pdpxl.file"
                        },
                        new Product()
                        {
                            Id = Guid.NewGuid(),
                            ProductCategoryId = Guid.Parse("3AEBBF07-2F89-4F2A-A95F-CAC3FB2C595F"),
                            ProductName = "Fifa 23",
                            Description = "Pc - Code in a Box (Ciab) ",
                            Quantity = 6,
                            Re_OrderLevel = 5,
                            Price = 999,
                            ImageURL = "https://media.takealot.com/covers_images/248b95eab69740d5ae87e0bd6ffc6dba/s-zoom.file"
                        },
                    });
                    context.SaveChanges();
                }
            }

        }
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
