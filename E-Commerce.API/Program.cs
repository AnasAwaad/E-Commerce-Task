using E_Commerce.API.Extensions;
using E_Commerce.API.Middlewares;
using E_Commerce.Application.Extensions;
using E_Commerce.Domain.Entities;
using E_Commerce.Infrastructure.Data.Seeds;
using E_Commerce.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
namespace E_Commerce.API
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.AddPresentaion();
			builder.Services
				.AddApplication()
				.AddInfrastructure(builder.Configuration);

			var app = builder.Build();

			app.UseMiddleware<ErrorHandlingMiddleware>();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			#region Seed Roles and Users
			var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
			using var scope = scopeFactory.CreateScope();

			var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

			await DefaultRoles.SeedRoles(roleManager);
			await DefaultUsers.SeedUsers(userManager);
			#endregion

			app.MapControllers();

			app.Run();
		}
	}
}
