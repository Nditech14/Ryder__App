using System;
using Microsoft.AspNetCore.Identity;
using Ryder.Domain.Entities;


namespace Ryder.Domain.SeedData
{
    public static class SeedData
    {
        public static void Initialize(UserManager<AppUser> userManager)
        {
            if (userManager.FindByEmailAsync("admin@gmail.com").Result == null)
            {
                AppUser user = new AppUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                };

                IdentityResult result = userManager.CreateAsync(user, "Password").Result;

                if (result.Succeeded)
                {
                    // Add any additional properties to the user if needed
                    // For example, user.FirstName = "John";
                }
            }
        }
    }

}
