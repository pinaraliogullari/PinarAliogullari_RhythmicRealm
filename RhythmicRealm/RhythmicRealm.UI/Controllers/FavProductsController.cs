using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Entity.Concrete.Identity;
using RhythmicRealm.Service.Abstract;

namespace RhythmicRealm.UI.Controllers
{
	public class FavProductsController : Controller
	{
	    private readonly IFavoriteService _favoriteService;
		private readonly INotyfService _notyfService;
		private readonly UserManager<User> _userManager;
		public FavProductsController(UserManager<User> userManager, IFavoriteService favoriteService, INotyfService notyfService)
		{
			_userManager = userManager;
			_favoriteService = favoriteService;
			_notyfService = notyfService;
		}

		public async Task<IActionResult> Index()
		{
			var userId = _userManager.GetUserId(User);
			var favProducts = await _favoriteService.GetAllFavoritesAsync(userId);
			return View(favProducts.Data);
		}

		public async Task<IActionResult> ToggleFavorite(int productId)
		{
			var userId = _userManager.GetUserId(User);
			var isFavorite = await _favoriteService.IsProductFavoriteAsync(userId, productId);

			if (isFavorite)
			{
				_notyfService.Information("Ürün favori listenizden çıkarıldı");
				await _favoriteService.RemoveFromFavoriteAsync(userId, productId);
			}
			else
			{
				_notyfService.Information("Ürün favori listenize eklendi");
				await _favoriteService.AddToFavoritesAsync(userId, productId);
			}
			var refererUrl = Request.Headers["Referer"].ToString();
			return Redirect(refererUrl);
		}
	}
}
