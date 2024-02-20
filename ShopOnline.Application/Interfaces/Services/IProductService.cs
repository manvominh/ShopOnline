using ShopOnline.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Application.Interfaces.Services
{
	public interface IProductService
	{
		Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId);
	}
}
