using E_Commerce.Application.Interfaces;
using E_Commerce.Application.Interfaces.Repositories;
using E_Commerce.Infrastructure.Data;

namespace E_Commerce.Infrastructure.Repositories;
internal class UnitOfWork : IUnitOfWork, IDisposable
{
	private readonly ApplicationDbContext _context;

	private readonly Lazy<IProductRepository> _productRepository;
	private readonly Lazy<ICategoryRepository> _categoryRepository;

	public UnitOfWork(ApplicationDbContext context)
	{
		_context = context;

		_productRepository = new Lazy<IProductRepository>(new ProductRepository(_context));
		_categoryRepository = new Lazy<ICategoryRepository>(new CategoryRepository(_context));
	}

	public IProductRepository Products => _productRepository.Value;
	public ICategoryRepository Categories => _categoryRepository.Value;

	public void Dispose()
	{
		_context.Dispose();
	}

	public async Task SaveChangesAsync()
	{
		await _context.SaveChangesAsync();
	}
}
