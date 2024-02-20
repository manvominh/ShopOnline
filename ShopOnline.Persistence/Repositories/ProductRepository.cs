using Microsoft.EntityFrameworkCore;
using ShopOnline.Application.Interfaces.Repositories;
using ShopOnline.Domain.Entities;
using ShopOnline.Persistence.Context;
using System.Numerics;

namespace ShopOnline.Persistence.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly IGenericRepository<Product> _repository;
		public ProductRepository(IGenericRepository<Product> repository)
		{
			_repository = repository;
		}
		public async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId, CancellationToken cancellationToken)
		{
			return await _repository.Entities.Where(x => x.CategoryId == categoryId).ToListAsync();
		}
	}
}
