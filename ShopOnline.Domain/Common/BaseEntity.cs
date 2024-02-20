
using ShopOnline.Domain.Common.Interfaces;

namespace ShopOnline.Domain.Common
{
	public class BaseEntity : IEntity
	{
		public int Id { get; set; }
	}
}
