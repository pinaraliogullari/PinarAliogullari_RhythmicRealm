using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Entity.Concrete.Identity;
using RhythmicRealm.Service.Abstract;

namespace RhythmicRealm.UI.ViewComponents
{
	public class CartViewComponent:ViewComponent
	{
		private readonly IShoppingBasketService _shoppingBasketService;
		private readonly IShoppingBasketItemService _shoppingBasketItemService;
		private readonly UserManager<User> _userManager;

		public CartViewComponent(IShoppingBasketService shoppingBasketService, UserManager<User> userManager, IShoppingBasketItemService shoppingBasketItemService)
		{
			_shoppingBasketService = shoppingBasketService;
			_userManager = userManager;
			_shoppingBasketItemService = shoppingBasketItemService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{

			var userId = _userManager.GetUserId(HttpContext.User);
			if (userId != null)
			{

				var shoppingBasket = await _shoppingBasketService.GetShoppingBasketByUserIdAsync(userId);
				var count = await _shoppingBasketItemService.CountAsync(shoppingBasket.Data.ShoppingBasketId);
				return View("Default", count);
			}
			return View("EmptyBasket");
		}
	}
}
