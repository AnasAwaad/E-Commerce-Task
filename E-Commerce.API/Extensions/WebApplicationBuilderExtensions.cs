using E_Commerce.API.Middlewares;
using E_Commerce.Domain.Entities;
using E_Commerce.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace E_Commerce.API.Extensions;

public static class WebApplicationBuilderExtensions
{
	public static void AddPresentaion(this WebApplicationBuilder builder)
	{
		builder.Services.AddControllers();

		builder.Services.AddScoped<ErrorHandlingMiddleware>();

		builder.Services.AddEndpointsApiExplorer();

		builder.Services.AddSwaggerGen(c =>
		{
			// Add JWT button to Swagger
			c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
			{
				Type = SecuritySchemeType.Http,
				Scheme = "bearer",
			});

			// Apply Bearer token to all operations
			c.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							}
						},
						[]
					}
				});
		});

		builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
		{
			options.Password.RequiredUniqueChars = 1;
			options.Password.RequireNonAlphanumeric = true;
			options.Password.RequireLowercase = true;
			options.Password.RequireUppercase = true;
			options.Password.RequireDigit = true;
			options.Password.RequiredLength = 6;

			options.User.RequireUniqueEmail = true;


		}).AddEntityFrameworkStores<ApplicationDbContext>();  // add classes that implement interfaces

		builder.Services.AddAuthentication(options =>
		{
			options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		})
		.AddJwtBearer(options =>
		{
			options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:Key"])),
				ValidateIssuer = true,
				ValidIssuer = builder.Configuration["Token:Issuer"],
				ValidateAudience = false

			};
		});



	}
}
