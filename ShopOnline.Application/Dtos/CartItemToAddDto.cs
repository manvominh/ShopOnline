using ShopOnline.Application.Common.Mappings;
using ShopOnline.Domain.Entities;

namespace ShopOnline.Application.Dtos
{
	public class CartItemToAddDto : IMapFrom<CartItem>
	{
		public int CartId { get; set; }
		public int ProductId { get; set; }
		public int Qty { get; set; }
	}
}
