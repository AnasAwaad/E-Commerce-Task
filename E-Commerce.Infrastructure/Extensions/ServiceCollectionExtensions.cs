using E_Commerce.Application.Interfaces;
using E_Commerce.Application.Interfaces.Services;
using E_Commerce.Infrastructure.Data;
using E_Commerce.Infrastructure.Repositories;
using E_Commerce.Infrastructure.Services;
using E_Commerce.Infrastructure.Settings;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Infrastructure.Extensions;
public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("DefaultConnection")
			?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

		services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

		services.AddScoped<IUnitOfWork, UnitOfWork>();
		services.Configure<CloudinarySettings>(configuration.GetSection("Cloudinary"));
		services.AddScoped<ICloudinaryService, CloudinaryService>();
		services.AddScoped<ITokenService, TokenService>();

		services.Configure<EmailSettings>(configuration.GetSection(nameof(EmailSettings)));
		services.AddScoped<IEmailSender, EmailSender>();
		return services;
	}
}
