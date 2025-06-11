using ArticleManagement.Domain.Entities;
using ArticleManagement.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleManagement.Infrastructure.Persistence
{
    public static class DataSeeder
    {

        public static async Task SeedAsync(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {

            if (!context.ArticleBicycleCategories.Any())
            {
                context.ArticleCategory.AddRange(new[]
                {
        new ArticleCategory { Name = "Hub" },
       
       
    });

                await context.SaveChangesAsync();
            }

            if (!context.BicycleCategories.Any())
            {
                var categories = new List<BicycleCategory>
        {
            new() { Name = "e-Cargo bike" },
          
        };
                context.BicycleCategories.AddRange(categories);
            }

            if (!context.Materials.Any())
            {
                var materials = new List<Material>
        {
            new() { Name = "Aluminium" },
          
        };
                context.Materials.AddRange(materials);
            }

            await context.SaveChangesAsync();

            // Add default user if not exists
            if (userManager.Users.All(u => u.UserName != "admin@example.com"))
            {
                var user = new ApplicationUser
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(user, "Admin@123");
            }
        }
    }

}
