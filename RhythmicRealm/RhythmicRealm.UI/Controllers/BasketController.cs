using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.ViewModels.ShoppingBasketViewModels;

namespace RhythmicRealm.UI.Controllers
{
	public class BasketController : Controller
	{
		private readonly IShoppingBasketService _shoppingBasketService;

		public BasketController(IShoppingBasketService shoppingBasketService)
		{
			_shoppingBasketService = shoppingBasketService;
		}

		public async Task<IActionResult> Index()
		{
			var shoppingCart = await _shoppingBasketService.GetBasketItemAsync();
			return View(shoppingCart.Data);
		}

		public async Task<IActionResult> AddToBasket(CreateBasketItemViewModel basketItem)
		{
			await _shoppingBasketService.AddItemToBasketAsync(basketItem);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> UpdateQuantityAsync(UpdateBasketItemViewModel basketItem)
		{
			await _shoppingBasketService.UpdateQuantityAsync(basketItem);
			return RedirectToAction("Index");
		}
	

		public async Task<IActionResult> RemoveBasketItem(int id)
		{
			await _shoppingBasketService.RemoveBasketItemAsync(id);
			return RedirectToAction("Index");
		}
	}
}
