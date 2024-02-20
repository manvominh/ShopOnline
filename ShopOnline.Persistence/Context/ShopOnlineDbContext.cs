
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ShopOnline.Domain.Entities;

namespace ShopOnline.Persistence.Context
{
	public class ShopOnlineDbContext : DbContext
	{
		public ShopOnlineDbContext(DbContextOptions<ShopOnlineDbContext> options)
			: base(options)
		{
			try
			{
				var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
				if (databaseCreator != null)
				{
					if (!databaseCreator.CanConnect()) databaseCreator.Create();
					if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		public DbSet<User> Users { get; set; }
		public DbSet<Cart> Carts { get; set; }
		public DbSet<CartItem> CartItems { get; set; }
		public DbSet<Product> Products { get; set; }  		
		public DbSet<ProductCategory> ProductCategories { get; set; }
	}
}
