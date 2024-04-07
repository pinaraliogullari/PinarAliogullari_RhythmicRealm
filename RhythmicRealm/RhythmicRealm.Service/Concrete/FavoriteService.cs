using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Entity.Concrete.Others;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.Response;

namespace RhythmicRealm.Service.Concrete
{
	public class FavoriteService : IFavoriteService
	{
		private readonly IFavoriteRepository _favoriteRepository;

		public FavoriteService(IFavoriteRepository favoriteRepository)
		{
			_favoriteRepository = favoriteRepository;
		}

		public async Task<Response<NoContent>> AddToFavoritesAsync(string userId, int productId)
		{
				var newFavorite = new Favorite
				{
					UserId = userId,
					ProductId = productId,
					CreatedDate = DateTime.Now
				};
				await _favoriteRepository.CreateAsync(newFavorite);
				return Response<NoContent>.Success(200);
		
		}

		public async Task<Response<List<Favorite>>> GetAllFavoritesAsync(string userId)
		{
			var favProducts = await _favoriteRepository.GetFavoritesAsync(userId);
			if (!favProducts.Any())
				return Response<List<Favorite>>.Fail(404, "Sonuç bulunamadı");

			return Response<List<Favorite>>.Success(favProducts, 200);
		}

		public async Task<bool> IsProductFavoriteAsync(string userId, int productId)
		{
			var favorites = await _favoriteRepository.GetFavoriteByProductAsync(userId, productId);
			return favorites.Any();
		}

		public async Task<Response<NoContent>> RemoveFromFavoriteAsync(string userId, int productId)
		{
			var existingFavorite = await _favoriteRepository.GetFavoritesAsync(userId);
			if (existingFavorite.Count != 0)
			{
				await _favoriteRepository.HardDeleteAsync(existingFavorite.FirstOrDefault());
				return Response<NoContent>.Success(200);
			}

			return Response<NoContent>.Fail(500, "İşlem başarısız");
		}
	}
	
}
