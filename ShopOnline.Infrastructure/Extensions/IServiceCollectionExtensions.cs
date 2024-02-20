using Microsoft.Extensions.DependencyInjection;
using ShopOnline.Application.Interfaces.Services;
using ShopOnline.Infrastructure.Services;

namespace ShopOnline.Infrastructure.Extensions
{
	public static class IServiceCollectionExtensions
	{
		public static void AddInfrastructureServiceLayer(this IServiceCollection services)
		{
			services.AddServices();
		}

		private static void AddServices(this IServiceCollection services)
		{
			services
				//.AddTransient<IJwtAuthenticationManagerService, JwtAuthenticationManagerService>()
				//.AddTransient<IUserService, UserService>()
				.AddTransient<IProductService, ProductService>()
				
				;
		}
	}
}
