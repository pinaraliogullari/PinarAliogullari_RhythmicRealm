using RhythmicRealm.Entity.Concrete.Others;
using RhythmicRealm.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Service.Abstract
{
	public interface IFavoriteService
	{
		Task<Response<NoContent>> AddToFavoritesAsync(string userId, int productId);
		Task<Response<List<Favorite>>> GetAllFavoritesAsync(string userId);
	}
}
