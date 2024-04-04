using RhythmicRealm.Entity.Concrete.Others;

namespace RhythmicRealm.Data.Abstract
{
    public interface IFavoriteRepository:IGenericRepository<Favorite>
	{
		Task<List<Favorite>> GetFavoritesAsync(string userId);
		Task<List<Favorite>> GetFavoriteByProductAsync(string userId, int productId);
		
	}
}
