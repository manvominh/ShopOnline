using ShopOnline.Application.Common.Mappings;
using ShopOnline.Domain.Entities;

namespace ShopOnline.Application.Dtos
{
	public class ProductDto : IMapFrom<Product>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string ImageURL { get; set; }
		public decimal Price { get; set; }
		public int Qty { get; set; }
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
	}
}
