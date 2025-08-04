using E_Commerce.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Interfaces;
public interface IUnitOfWork
{
	public ICategoryRepository Categories { get; }
	public IProductRepository Products { get; }
	Task SaveChangesAsync();
}
