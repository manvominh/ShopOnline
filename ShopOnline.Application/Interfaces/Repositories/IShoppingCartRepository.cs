using ShopOnline.Domain.Entities;

namespace ShopOnline.Application.Interfaces.Repositories
{
	public interface IShoppingCartRepository
	{
		Task<IEnumerable<CartItem>> GetItems(int userId);
	}
}
