using ShopOnline.Domain.Common;

namespace ShopOnline.Domain.Entities
{
	public class CartItem : BaseEntity
	{
		public int CartId { get; set; }
		public int ProductId { get; set; }
		public int Qty { get; set; }
	}
}
