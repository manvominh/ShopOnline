using ShopOnline.Domain.Common;

namespace ShopOnline.Application.Interfaces.Repositories
{
	public interface IUnitOfWork
	{
		IGenericRepository<T> Repository<T>() where T : BaseEntity;//BaseAuditableEntity;
		Task<int> Save(CancellationToken cancellationToken);
		Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys);
		Task Rollback();
	}
}
