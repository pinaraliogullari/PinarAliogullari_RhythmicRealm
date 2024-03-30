using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Entity.Concrete;
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
            if (User.Identity.IsAuthenticated)
            {
				var basket = await _shoppingBasketService.GetShoppingBasketByUserIdAsync(_userManager.GetUserId(User));
				return View(basket.Data);
			}
            return RedirectToAction("Login", "Account");
       
        }

        [HttpPost]
        public async Task<IActionResult> AddToBasket(int productId,int quantity)
        {
            //productdetaildeyken sepete ekle deyince product detail sayfasında kalsın istiyorum .
		     await _shoppingBasketService.AddItemToBasketAsync(_userManager.GetUserId(User),productId, quantity);
            _notyfService.Success("Ürün sepetine eklendi");
            return RedirectToAction("Index", "Home");
        }

  
        public async Task<IActionResult> RemoveFromBasket(int productId)
        {
            await _shoppingBasketService.RemoveItemFromBasketAsync(_userManager.GetUserId(User),productId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int itemId, int quantity)
        {
            var userId= _userManager.GetUserId(User);
            var basket= await _shoppingBasketService.UpdateQuantityAsync(itemId, quantity,userId);
            var basketItem = basket.Data.BasketItems.FirstOrDefault(x=>x.BasketItemId==itemId);
            var basketItemTotal= $"{(basketItem.Price * quantity):C0}";
            var basketTotal = $"{basket.Data.TotalPrice():C0}";
            var discount = $"{(basket.Data.TotalPrice() * 0.1m):C0}";
            var newTotal = basket.Data.TotalPrice() - basket.Data.TotalPrice() * 0.1m;
			return Json(new
			{
				basketItemTotal = basketItemTotal,
				basketTotal = basketTotal,
				discount = discount,
                newTotal= newTotal
			});

		}


    }
}
