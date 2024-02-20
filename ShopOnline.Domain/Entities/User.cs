using ShopOnline.Domain.Common;

namespace ShopOnline.Domain.Entities
{
	public class User : BaseEntity
	{
		public string UserName { get; set; }
		public string Password { get; set; } = string.Empty;
	}
}
