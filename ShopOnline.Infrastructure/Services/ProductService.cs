
using ShopOnline.Application.Interfaces.Repositories;
using ShopOnline.Application.Interfaces.Services;
using ShopOnline.Domain.Entities;

namespace ShopOnline.Infrastructure.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;
		private readonly IUnitOfWork _unitOfWork;
		public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
		{
			_productRepository = productRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId, c)
		{
			return await _productRepository.GetProductsByCategoryId(categoryId);
		}
	}
}
