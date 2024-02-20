using ShopOnline.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.Domain.Entities
{
	[Table("Categories")]
	public class ProductCategory : BaseAuditableEntity
	{
		public string Name { get; set; }
		public string IconCSS { get; set; }
	}
}
