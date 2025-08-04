using E_Commerce.Domain.Constants;
using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Interfaces.Repositories;
public interface IProductRepository : IGenericRepository<Product>
{
	Task<IEnumerable<Product>> GetAllWithCategory();
	Task<(int, IEnumerable<Product>)> GetAllMatchingAsync(int pageNumber, int pageSize, string? search, string? sortBy, SortDirection sortDirection);
}
