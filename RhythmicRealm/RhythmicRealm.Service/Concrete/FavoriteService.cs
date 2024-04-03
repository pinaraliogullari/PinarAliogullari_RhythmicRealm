using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Entity.Concrete.Others;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

			var existingFavorite = await _favoriteRepository.GetFavoritesAsync(userId);
			if (existingFavorite.Count==0)
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

			return Response<NoContent>.Fail(500, "İşlem başarısız");
		}

		public async Task<Response<List<Favorite>>> GetAllFavoritesAsync(string userId)
		{
			var favProducts = await _favoriteRepository.GetFavoritesAsync(userId);
			if (!favProducts.Any())
				return Response<List<Favorite>>.Fail(404, "Sonuç bulunamadı");

			return Response<List<Favorite>>.Success(favProducts, 200);
		}
	}
	
}
