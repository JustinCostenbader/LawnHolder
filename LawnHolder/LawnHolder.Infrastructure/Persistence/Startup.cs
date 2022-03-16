using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LawnHolder.Infrastructure.Persistence.DbContexts;

namespace LawnHolder.Infrastructure.Persistence;

public static class Startup
{
	/// <summary>
	///     Adds all Entity Framework database contexts to the service collection
	/// </summary>
	public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<ApplicationDbContext>(options =>
		{
			options.UseSqlServer(configuration.GetConnectionString("AppContext"),
				x => x.MigrationsAssembly("LawnHolder.Infrastructure"));
		}, optionsLifetime: ServiceLifetime.Singleton, contextLifetime: ServiceLifetime.Scoped);

		services.AddDbContextFactory<ApplicationDbContext>(options =>
		{
			options.UseSqlServer(configuration.GetConnectionString("AppContext"),
				x => x.MigrationsAssembly("LawnHolder.Infrastructure"));
		});
    }

	public static void Configure(IApplicationBuilder app, IConfiguration configuration)
	{
	}
}

