using RhythmicRealm.Entity.Concrete.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Data.Abstract
{
	public interface IFavoriteRepository:IGenericRepository<Favorite>
	{
		Task<List<Favorite>> GetFavoritesAsync(string userId);
		
	}
}
