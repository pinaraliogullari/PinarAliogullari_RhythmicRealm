using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Entity.Concrete.Identity;
using RhythmicRealm.Service.Abstract;

namespace RhythmicRealm.UI.Controllers
{
	public class FavProductsController : Controller
	{
	    private readonly IFavoriteService _favoriteService;
		private readonly UserManager<User> _userManager;
		public FavProductsController(UserManager<User> userManager, IFavoriteService favoriteService)
		{
			_userManager = userManager;
			_favoriteService = favoriteService;
		}

		public async Task<IActionResult> Index()
		{
			var userId = _userManager.GetUserId(User);
			var favProducts = await _favoriteService.GetAllFavoritesAsync(userId);
			return View(favProducts.Data);
		}

		
		public async Task<IActionResult> AddToFavs(int productId)
		{
			var refererUrl = Request.Headers["Referer"].ToString();
			var userId = _userManager.GetUserId(User);
			await _favoriteService.AddToFavoritesAsync(userId, productId);
			return Redirect(refererUrl);
		}
	}
}
