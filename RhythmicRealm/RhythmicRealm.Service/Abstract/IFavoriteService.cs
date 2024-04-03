using RhythmicRealm.Entity.Concrete.Others;
using RhythmicRealm.Shared.Response;

namespace RhythmicRealm.Service.Abstract
{
	public interface IFavoriteService
	{
		Task<Response<NoContent>> AddToFavoritesAsync(string userId, int productId);
		Task<Response<NoContent>> RemoveFromFavoriteAsync(string userId, int productId);
		Task<Response<List<Favorite>>> GetAllFavoritesAsync(string userId);
		Task<bool> IsProductFavoriteAsync(string userId, int productId);
	}
}
