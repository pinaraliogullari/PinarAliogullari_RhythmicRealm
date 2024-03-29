using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Entity.Concrete.Identity;
using RhythmicRealm.Service.Abstract;

namespace RhythmicRealm.UI.Controllers
{
	public class BasketController : Controller
	{
		private readonly IShoppingBasketService _shoppingBasketService;
		private readonly UserManager<User> _userManager;
        private readonly INotyfService _notyfService;
        public BasketController(IShoppingBasketService shoppingBasketService, UserManager<User> userManager, INotyfService notyfService)
        {
            _shoppingBasketService = shoppingBasketService;
            _userManager = userManager;
            _notyfService = notyfService;
        }

        public async Task<IActionResult> Index()
		{
            var basket = await _shoppingBasketService.GetShoppingBasketByUserIdAsync(_userManager.GetUserId(User));
            return View(basket.Data);
        }

        [HttpPost]
        public async Task<IActionResult> AddToBasket(int productId,int quantity)
        {
            //productdetaildeyken sepete ekle deyince product detail sayfasında kalsın istiyorum .
			var filledBasket=await _shoppingBasketService.AddItemToBasketAsync(_userManager.GetUserId(User),productId, quantity);
            _notyfService.Success("Ürün sepetine eklendi");
            return RedirectToAction("Index", "Home");
        }

  
        public async Task<IActionResult> RemoveFromBasket(int productId)
        {
            await _shoppingBasketService.RemoveItemFromBasketAsync(_userManager.GetUserId(User),productId);
            return RedirectToAction("Index");
        }


	}
}
