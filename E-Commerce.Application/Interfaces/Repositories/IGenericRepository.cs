using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Interfaces.Repositories;
public interface IGenericRepository<T> where T : BaseEntity
{
	Task CreateAsync(T entity);
	void Delete(T entity);
	Task<IEnumerable<T>> GetAllAsync();
	Task<T?> GetByIdAsync(int id);
	void Update(T entity);
	void RemoveRange(IEnumerable<T> entities);
}
