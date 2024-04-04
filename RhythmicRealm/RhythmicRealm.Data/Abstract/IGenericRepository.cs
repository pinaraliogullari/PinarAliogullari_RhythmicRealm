using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace RhythmicRealm.Data.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : class
	{
		//CRUD İŞLEMLERİ
		Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> options = null, 
			Func<IQueryable<TEntity>,
			 IIncludableQueryable<TEntity, object>> include = null);
		Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> options = null,
			Func<IQueryable<TEntity>,
		   IIncludableQueryable<TEntity, object>> include = null);
		Task<int> GetCountAsync(Expression<Func<TEntity, bool>> options = null,
			Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
		Task<TEntity> CreateAsync(TEntity entity);
		Task UpdateAsync(TEntity entity);
		Task HardDeleteAsync(TEntity entity);
		Task<bool> AnyAsync(Expression<Func<TEntity, bool>> options);
		Task<int> GetCount(
		Expression<Func<TEntity, bool>> options = null, Func<IQueryable<TEntity>,
		IIncludableQueryable<TEntity, object>> include = null
	);
	}
}
