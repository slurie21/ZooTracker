using Microsoft.AspNetCore.Identity;
using ZooTracker.Utility.IRepo;
using ZooTracker.Models.Entity;

namespace ZooTracker.Utility
{
    public class RoleSeeding : IRoleSeeding
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleSeeding(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task SeedRolesAsync()
        {
            // List of roles to seed
            string[] roleNames = ["Admin","User"];

            foreach (var roleName in roleNames)
            {
                var roleExist = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    // Create the roles and seed them to the database
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            await SeedDefaultUserAsync();
        }

        private async Task SeedDefaultUserAsync()
        {
            var adminEmail = "admin@admin.com"; // Use a valid email
            var defaultAdmin = await _userManager.FindByEmailAsync(adminEmail);

            if (defaultAdmin == null)
            {
                
                var newAdmin = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true, // Set to false if email confirmation is required
                    Fname = "Samuel",
                    Lname = "Lurie",
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow,
                };

                var createUserResult = await _userManager.CreateAsync(newAdmin, "Testing123"); // Use a strong password
                if (createUserResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newAdmin, "Admin");
                }
                // Handle any errors or further actions like logging here
            }
        }
    }
}


