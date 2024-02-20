using Microsoft.EntityFrameworkCore;
using ShopOnline.Application.Interfaces.Repositories;
using ShopOnline.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Persistence.Repositories
{
	public class ShoppingCartRepository : IShoppingCartRepository
	{
		private readonly IGenericRepository<CartItem> _repository;

		public ShoppingCartRepository(IGenericRepository<CartItem> repository)
		{
			_repository = repository;
		}
		public Task<IEnumerable<CartItem>> GetItems(int userId)
		{
			throw new NotImplementedException();
			//return await _repository.Entities.Include<Cart>.Where(x => x. == categoryId).ToListAsync();
		}
	}
}
