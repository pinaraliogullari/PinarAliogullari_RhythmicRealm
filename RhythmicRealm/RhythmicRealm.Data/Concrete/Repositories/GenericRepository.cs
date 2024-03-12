using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RhythmicRealm.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Data.Concrete.Repositories
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
	{
		protected readonly DbContext _dbContext;

		public GenericRepository(DbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> options)
		{
			return await _dbContext.Set<TEntity>().AnyAsync(options);
		}

		public async Task<TEntity> CreateAsync(TEntity entity)
		{
			await _dbContext.AddAsync(entity);
			await _dbContext.SaveChangesAsync();
			return entity;
		}

		public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> options = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
		{
			IQueryable<TEntity> query = _dbContext.Set<TEntity>();
			if (include != null)
			{
				query = include(query);
			}
			if (options != null)
			{
				query = query.Where(options);
			}

			return await query.ToListAsync();
		}

		public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> options = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
		{
			IQueryable<TEntity> query = _dbContext.Set<TEntity>();
			if (include != null)
			{
				query = include(query);
			}
			if (options != null)
			{
				query = query.Where(options);
			}
			return await query.FirstOrDefaultAsync();
			// return await query.SingleOrDefaultAsync(); birden fazla veri olması durumunda hata verir.
		}

		public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> options = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
		{
			IQueryable<TEntity> query = _dbContext.Set<TEntity>();
			if (include != null)
			{
				query = include(query);
			}
			if (options != null)
			{
				query = query.Where(options);
			}
			return await query.CountAsync();
		}

		public async Task HardDeleteAsync(TEntity entity)
		{
			_dbContext.Set<TEntity>().Remove(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task UpdateAsync(TEntity entity)
		{
			_dbContext.Set<TEntity>().Update(entity);
			await _dbContext.SaveChangesAsync();
		}
	}
}
