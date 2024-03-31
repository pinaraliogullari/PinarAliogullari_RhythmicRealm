using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Entity.Concrete.Identity;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.ViewModels.OrderViewModels;

namespace RhythmicRealm.UI.Controllers
{
	[Authorize]
	public class CheckOutController : Controller
	{

		private readonly IShoppingBasketService _shoppingBasketService;
		private readonly IOrderService _orderService;
		private readonly IShoppingBasketItemService _shoppingBasketItemService;
		private readonly UserManager<User> _userManager;

		public CheckOutController(IShoppingBasketService shoppingBasketService, IOrderService orderService, IShoppingBasketItemService shoppingBasketItemService, UserManager<User> userManager)
		{
			_shoppingBasketService = shoppingBasketService;
			_orderService = orderService;
			_shoppingBasketItemService = shoppingBasketItemService;
			_userManager = userManager;
		}

		public async Task<IActionResult> Checkout()
		{
			var user = await _userManager.FindByIdAsync(_userManager.GetUserId(User));
			var basket = await _shoppingBasketService.GetShoppingBasketByUserIdAsync(_userManager.GetUserId(User));
			var orderViewModel = new OrderViewModel
			{
				FirstName = user.FirstName,
				LastName = user.LastName,
				Address = user.Address,
				City = user.City,
				Email = user.Email,
				PhoneNumber = user.PhoneNumber,
				CardName = "David Bowie",
				CardNumber = "5170410000000004",
				ExpirationMonth = "4",
				ExpirationYear = "2028",
				Cvc = "286",
				ShoppingBasket = basket.Data
			};
			return View(orderViewModel);
	
		}
	}
}
