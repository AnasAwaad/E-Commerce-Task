using E_Commerce.Application.Interfaces.Repositories;
using E_Commerce.Domain.Entities;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
	protected readonly ApplicationDbContext _context;
	protected readonly DbSet<T> _dbSet;
	public GenericRepository(ApplicationDbContext context)
	{
		_context = context;
		_dbSet = _context.Set<T>();
	}
	public void Delete(T entity)
	{
		_dbSet.Remove(entity);
	}

	public async Task<IEnumerable<T>> GetAllAsync()
	{
		return await _dbSet.AsNoTracking().ToListAsync();
	}

	public async Task<T?> GetByIdAsync(int id)
	{
		return await _dbSet.FindAsync(id);
	}

	public async Task CreateAsync(T entity)
	{
		await _dbSet.AddAsync(entity);
	}

	public void Update(T entity)
	{
		_dbSet.Update(entity);
	}

	public void RemoveRange(IEnumerable<T> entities)
	{
		_dbSet.RemoveRange(entities);
	}
}