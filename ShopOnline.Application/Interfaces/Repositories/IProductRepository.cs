using ShopOnline.Domain.Entities;

namespace ShopOnline.Application.Interfaces.Repositories
{
	public interface IProductRepository
	{
		Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId, CancellationToken cancellationToken);
	}
}
