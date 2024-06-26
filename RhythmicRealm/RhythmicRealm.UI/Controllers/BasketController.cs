﻿using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Entity.Concrete.Identity;
using RhythmicRealm.Service.Abstract;

namespace RhythmicRealm.UI.Controllers
{
	public class BasketController : Controller
	{
		private readonly IShoppingBasketService _shoppingBasketService;
        private readonly IShoppingBasketItemService _shoppingBasketItemService;
		private readonly UserManager<User> _userManager;
        private readonly INotyfService _notyfService;
		public BasketController(IShoppingBasketService shoppingBasketService, UserManager<User> userManager, INotyfService notyfService, IShoppingBasketItemService shoppingBasketItemService)
		{
			_shoppingBasketService = shoppingBasketService;
			_userManager = userManager;
			_notyfService = notyfService;
			_shoppingBasketItemService = shoppingBasketItemService;
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
			var refererUrl = Request.Headers["Referer"].ToString();
			await _shoppingBasketService.AddItemToBasketAsync(_userManager.GetUserId(User),productId, quantity);
            _notyfService.Success("Ürün sepetine eklendi");
            return Redirect(refererUrl);
        }

  
        public async Task<IActionResult> RemoveFromBasket(int productId)
        {
            await _shoppingBasketService.RemoveItemFromBasketAsync(_userManager.GetUserId(User),productId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int shoppingBasketItemId, int quantity)
        {
         
            await _shoppingBasketItemService.UpdateQuantityAsync(shoppingBasketItemId, quantity);
			var shoppingBasketItem= await _shoppingBasketItemService.GetShoppingBasketItemAsync(shoppingBasketItemId);
            var basketItemTotal = $"{(shoppingBasketItem.Data.Price * quantity):C2}";
			var userId = _userManager.GetUserId(User);
			var basket = await _shoppingBasketService.GetShoppingBasketByUserIdAsync(userId);
			var basketTotal = (basket.Data.TotalPrice()).ToString("C2");
			var discount = ((basket.Data.TotalPrice() * 0.1m)).ToString("C2");
			var newTotal = ((basket.Data.TotalPrice()) - (basket.Data.TotalPrice() * 0.1m)).ToString("C2");
			return Json(new
			{
                success=true,
				basketItemTotal = basketItemTotal,
				basketTotal = basketTotal,
				discount = discount,
                newTotal= newTotal
			});

		}


    }
}
