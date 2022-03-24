using Microsoft.AspNetCore.Identity;
using RoverCore.Abstractions.Seeder;
using LawnHolder.Domain.Entities.Identity;
using LawnHolder.Infrastructure.Common.Seeder.Services;

namespace LawnHolder.Infrastructure.Identity.Seeding;

public class ApplicationRoleSeed : ISeeder
{
    private readonly RoleManager<ApplicationRole> _roleManager;

    public int Priority { get; } = 1001;

    public ApplicationRoleSeed(RoleManager<ApplicationRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public void CreateRoles()
    {
        var roles = new List<string>
        {
            "Admin",
            "User",
            "Business",
            "Customer"
        };

        foreach (var roleName in roles)
        {
            if (!_roleManager.RoleExistsAsync(roleName).Result)
            {
                var role = new ApplicationRole { Id = Guid.NewGuid().ToString(), Name = roleName };

                _roleManager.CreateAsync(role).Wait();
            }
        }
    }

    public Task SeedAsync()
    {
        CreateRoles();

        return Task.CompletedTask;
    }
}