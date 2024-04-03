using Microsoft.EntityFrameworkCore;
using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Data.Concrete.Contexts;
using RhythmicRealm.Entity.Concrete.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Data.Concrete.Repositories
{
	public class FavoriteRepository:GenericRepository<Favorite>,IFavoriteRepository
	{
        public FavoriteRepository(RRContext _context):base(_context)
        {
            
        }
        private RRContext RRContext
        {
            get { return _dbContext as RRContext;}
        }

		public async Task<List<Favorite>> GetFavoriteByProductAsync(string userId, int productId)
		{
			var favorites = await RRContext.Favorites
				.Include(x => x.Product)
				.ThenInclude(x => x.SubCategory)
				.ThenInclude(x => x.MainCategory)
				.Where(x => x.UserId == userId &&x.ProductId==productId)
				.ToListAsync();

			return favorites;
		}

		public async Task<List<Favorite>> GetFavoritesAsync(string userId)
		{
			var favorites = await RRContext.Favorites
				.Include(x => x.Product)
				.ThenInclude(x => x.SubCategory)
				.ThenInclude(x => x.MainCategory)
			    .Where(x => x.UserId == userId)
			    .ToListAsync(); 
				
			return favorites;
		}
	}
}
