using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Interfaces.Services;
public interface ITokenService
{
	string GenerateToken(ApplicationUser appUser, string role);
}
