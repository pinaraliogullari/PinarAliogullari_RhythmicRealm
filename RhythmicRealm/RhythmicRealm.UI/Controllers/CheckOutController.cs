using AspNetCoreHero.ToastNotification.Abstractions;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Entity.Concrete;
using RhythmicRealm.Entity.Concrete.Identity;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.ComplexTypes;
using RhythmicRealm.Shared.ViewModels.OrderViewModels;
using RhythmicRealm.Shared.ViewModels.ShoppingBasketViewModels;

namespace RhythmicRealm.UI.Controllers
{
	[Authorize]
	public class CheckOutController : Controller
	{

		private readonly IShoppingBasketService _shoppingBasketService;
		private readonly IOrderService _orderService;
		private readonly UserManager<User> _userManager;
		private readonly INotyfService _notyfService;
		public CheckOutController(IShoppingBasketService shoppingBasketService, IOrderService orderService, UserManager<User> userManager, INotyfService notyfService)
		{
			_shoppingBasketService = shoppingBasketService;
			_orderService = orderService;
			_userManager = userManager;
			_notyfService = notyfService;
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
				CardName = user.FirstName + " " + user.LastName,
				CardNumber = "5170410000000004",
				ExpirationMonth = "4",
				ExpirationYear = "2028",
				Cvc = "286",
				ShoppingBasket = basket.Data
			};
			return View(orderViewModel);
	
		}

		private Payment PaymentProcess(OrderViewModel orderViewModel)
		{
			var userId = _userManager.GetUserId(User);


			Options options = new Options();
			options.ApiKey = "sandbox-2VZs9tMkbi5Y2ibjdzKXZIuYKEMO6Wl0";
			options.SecretKey = "sandbox-aGn2UCTrQHPMvp9kF0LL6oM9SgImvDIV";
			options.BaseUrl = "https://sandbox-api.iyzipay.com";

			CreatePaymentRequest request = new CreatePaymentRequest();
			request.Locale = Locale.TR.ToString();
			request.ConversationId = Guid.NewGuid().ToString();
			request.Price = orderViewModel.ShoppingBasket.TotalPrice().ToString().Split(",")[0];
			request.PaidPrice = orderViewModel.ShoppingBasket.TotalPrice().ToString().Split(',')[0];
			request.Currency=Currency.TRY.ToString();
			request.Installment = 1;
			request.BasketId = orderViewModel.ShoppingBasket.ShoppingBasketId.ToString();
			request.PaymentChannel = PaymentChannel.WEB.ToString();
			request.PaymentGroup=PaymentGroup.PRODUCT.ToString();

			PaymentCard paymentCard= new PaymentCard();
			paymentCard.CardHolderName = orderViewModel.CardName;
			paymentCard.CardNumber=orderViewModel.CardNumber;
			paymentCard.ExpireMonth = orderViewModel.ExpirationMonth;
			paymentCard.ExpireYear = orderViewModel.ExpirationYear;
			paymentCard.Cvc = orderViewModel.Cvc;
			paymentCard.RegisterCard = 0;
			request.PaymentCard = paymentCard;

			Buyer buyer = new Buyer();
			buyer.Id = userId;
			buyer.Name = orderViewModel.FirstName;
			buyer.Surname = orderViewModel.LastName;
			buyer.GsmNumber = orderViewModel.PhoneNumber;
			buyer.Email=orderViewModel.Email;
			buyer.IdentityNumber = "74300864791";
			buyer.LastLoginDate = "20124-03-05 12:43:35";
			buyer.RegistrationDate = "2013-04-21 15:12:09";
			buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
			buyer.Ip = "85.34.78.112";
			buyer.City = orderViewModel.City;
			buyer.Country = "Türkiye";
			buyer.ZipCode = "34732";
			request.Buyer = buyer;

			Address shippingAddress = new Address();
			shippingAddress.ContactName = "Jane Doe";
			shippingAddress.City = "Istanbul";
			shippingAddress.Country = "Turkey";
			shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
			shippingAddress.ZipCode = "34742";
			request.ShippingAddress = shippingAddress;

			Address billingAddress = new Address();
			billingAddress.ContactName = "Jane Doe";
			billingAddress.City = "Istanbul";
			billingAddress.Country = "Turkey";
			billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
			billingAddress.ZipCode = "34742";
			request.BillingAddress = billingAddress;

			List<BasketItem> basketItems= new List<BasketItem>();
			BasketItem basketItem;
			foreach (var item in orderViewModel.ShoppingBasket.BasketItems)
			{
				basketItem = new BasketItem();
				basketItem.Id = item.ProductId.ToString();
				basketItem.Name = item.Name;
				basketItem.Category1 = "Tuşlular";
				basketItem.Category2 = "";
				basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
				basketItem.Price = item.Price.ToString().Split(",")[0];

				basketItems.Add(basketItem);
			}

			request.BasketItems = basketItems;

			return Payment.Create(request, options);
		}

		private void SaveOrder(OrderViewModel orderViewModel, Payment payment, string userId)
		{
			var order = new Order();
			order.OrderNumber= new Random().Next(111111,999999).ToString();
			order.OrderState = EnumOrderState.Received;
			order.PaymentOptions = EnumPaymentOptions.CreditCard;
			order.PaymentId = payment.PaymentId;
			order.ConversationId = payment.ConversationId;
			order.OrderDate = DateTime.Now;
			order.FirstName = orderViewModel.FirstName;
			order.LastName = orderViewModel.LastName;
			order.Email= orderViewModel.Email;
			order.PhoneNumber = orderViewModel.PhoneNumber;
			order.Address = orderViewModel.Address;
			order.UserId= userId;

			foreach (var item in orderViewModel.ShoppingBasket.BasketItems)
			{
				var orderItem = new Entity.Concrete.OrderItem()
				{
					Price = item.Price,
					Quantity = item.Quantity,
					ProductId = item.ProductId,
				};
				order.OrderItems.Add(orderItem);
			}
			_orderService.CreateOrderAsync(order);
		}

		private void ClearBasket(int basketId)
		{
			_shoppingBasketService.RemoveBasketAsync(basketId);
		}

		[HttpPost]
		public async Task<IActionResult>Checkout(OrderViewModel orderViewModel)
		{
			if (ModelState.IsValid)
			{
				var userId = _userManager.GetUserId(User);
				var basket = await _shoppingBasketService.GetShoppingBasketByUserIdAsync(userId);
				orderViewModel.ShoppingBasket = new ShoppingBasketViewModel()
				{
					ShoppingBasketId = basket.Data.ShoppingBasketId,
					BasketItems = basket.Data.BasketItems.Select(x => new ShoppingBasketItemViewModel()
					{
						BasketItemId = x.BasketItemId,
						ProductId=x.ProductId,
						Price= (decimal)x.Price,
						Name=x.Name,
						ImageUrl=x.ImageUrl,
						Quantity=x.Quantity,


					}).ToList(),
				};
				var payment = PaymentProcess(orderViewModel);
				if (payment.Status == "success")
				{
					SaveOrder(orderViewModel, payment, userId);
					ClearBasket(basket.Data.ShoppingBasketId);
					_notyfService.Success("Siparişiniz alınmıştır.");
					return Redirect("~/");
				}
				ModelState.AddModelError("",payment.ErrorMessage);

			}	
			return View(orderViewModel);
		}

		public async Task<IActionResult> GetOrders()
		{
			var orders = await _orderService.GetOrdersAsync();
			return View(orders.Data);
		}
        public async Task<IActionResult> GetOngoingOrders(EnumOrderState orderState)
        {
            var ongoingOrders = await _orderService.GetOrdersByOrderStateAsync(orderState); 
            return View("GetOrders", ongoingOrders.Data); 
        }
        public async Task<IActionResult> GetDeliveredOrders(EnumOrderState orderState)
        {
            var deliveredOrders = await _orderService.GetOrdersByOrderStateAsync(orderState); 
            return View("GetOrders", deliveredOrders.Data); 
        }
		
		public async Task<IActionResult> OrderDetails(int id)
		{
			var order = await _orderService.GetOrderAsync(id);
			return View(order.Data);
		}
    }
}
