using ShopOnline.Application.Common.Mappings;
using ShopOnline.Domain.Entities;

namespace ShopOnline.Application.Dtos
{
	public class ProductCategoryDto : IMapFrom<ProductCategory>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string IconCSS { get; set; }
	}
}
