using E_Commerce.Application.Interfaces.Repositories;
using E_Commerce.Domain.Constants;
using E_Commerce.Domain.Entities;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_Commerce.Infrastructure.Repositories;
internal class ProductRepository : GenericRepository<Product>, IProductRepository
{
	public ProductRepository(ApplicationDbContext context) : base(context)
	{
	}

	public async Task<IEnumerable<Product>> GetAllWithCategory()
	{
		return await _context.Products
			.Include(p => p.Category)
			.ToListAsync();
	}

	public async Task<(int, IEnumerable<Product>)> GetAllMatchingAsync(int pageNumber, int pageSize, string? search, string? sortBy, SortDirection sortDirection)
	{
		var searchValue = search?.ToLower().Trim();

		var query = _context.Products
			.Where(j => searchValue == null || (j.Name!.ToLower().Contains(searchValue) ||
														(j.Description!.ToLower().Contains(searchValue))));

		var totalCount = await query.CountAsync();


		if (sortBy is not null)
		{
			var columnsSelector = new Dictionary<string, Expression<Func<Product, object>>>()
			{
				{nameof(Product.Name),j=>j.Name},
				{nameof(Product.Description),j=>j.Description}
			};

			var selectedColumn = columnsSelector[sortBy];

			query = (sortDirection == SortDirection.Ascending)
				? query.OrderBy(selectedColumn)
				: query.OrderByDescending(selectedColumn);
		}


		var jobs = await query
			.Skip(pageSize * (pageNumber - 1))
			.Take(pageSize)
			.Include(j => j.Category)
			.ToListAsync();



		return (totalCount, jobs);
	}
}