using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Data.Abstract
{
	public interface IGenericRepository<TEntity> where TEntity : class
	{
		DbSet<TEntity> Table { get; set; }
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
	}
}
