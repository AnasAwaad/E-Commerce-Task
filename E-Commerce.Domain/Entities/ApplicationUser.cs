using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Domain.Entities;
public class ApplicationUser : IdentityUser
{
	public string FullName { get; set; } = null!;
}
