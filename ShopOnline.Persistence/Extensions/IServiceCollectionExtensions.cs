
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopOnline.Application.Interfaces.Repositories;
using ShopOnline.Persistence.Context;
using ShopOnline.Persistence.Repositories;
using System.Reflection;

namespace ShopOnline.Persistence.Extensions
{
	public static class IServiceCollectionExtensions
	{
		public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddMappings();
			services.AddDbContext(configuration);
			services.AddRepositories();
		}

		private static void AddMappings(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
		}

		public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection");

			services.AddDbContext<ShopOnlineDbContext>(options =>
			   options.UseSqlServer(connectionString,
				   builder => builder.MigrationsAssembly(typeof(ShopOnlineDbContext).Assembly.FullName)));
		}

		private static void AddRepositories(this IServiceCollection services)
		{
			services
				.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
				.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
			.AddTransient<IProductRepository, ProductRepository>()
			//.AddTransient<IProductCategoryRepository, ProductCategoryRepository>()
			//.AddTransient<IShoppingCartRepository, ShoppingCartRepository>()
			;
		}
	}
}
