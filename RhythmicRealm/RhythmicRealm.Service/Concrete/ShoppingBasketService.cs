using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Entity.Concrete;
using RhythmicRealm.Entity.Concrete.Identity;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.ShoppingBasketViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Service.Concrete
{
	public class ShoppingBasketService : IShoppingBasketService
	{
		private readonly UserManager<User> _userManager;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IOrderRepository _orderRepository;
		private readonly IShoppingBasketRepository _shoppingBasketRepository;
		private readonly IShoppingBasketItemRepository _shoppingBasketItemRepository;

		public ShoppingBasketService(UserManager<User> userManager, IHttpContextAccessor contextAccessor, IOrderRepository orderRepository, IShoppingBasketRepository shoppingBasketRepository, IShoppingBasketItemRepository shoppingBasketItemRepository)
		{
			_userManager = userManager;
			_httpContextAccessor = contextAccessor;
			_orderRepository = orderRepository;
			_shoppingBasketRepository = shoppingBasketRepository;
			_shoppingBasketItemRepository = shoppingBasketItemRepository;
		}

		private async Task<ShoppingBasket> ContextUser()
		{
			var username = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;
			if(!string.IsNullOrEmpty(username) )
			{
				User? user= await _userManager.Users
				.Include(u => u.ShoppingBaskets)
				.FirstOrDefaultAsync(u=>u.UserName == username);
				var _basket = from basket in user.ShoppingBaskets
							  join order in _orderRepository.Table
							  on basket.Id equals order.Id into orders
							  from o in orders.DefaultIfEmpty()
							  select new
							  {
								  basket,
								  orders
							  };
				ShoppingBasket? targetBasket = null;
				if (_basket.Any(b => b.orders is null))
					targetBasket = _basket.FirstOrDefault(b => b.orders is null)?.basket;
				else
				{
					targetBasket = new();
					user.ShoppingBaskets.Add(targetBasket);
				}
				await _shoppingBasketRepository.CreateAsync(targetBasket);
				return targetBasket;
				
			}
			throw new Exception("Beklenmeyen bir hata ile karşılaşıldı");
			
		}
		public async Task<Response<NoContent>> AddItemToBasketAsync(CreateBasketItemViewModel basketItem)
		{
			ShoppingBasket? basket = await ContextUser();
			if (basket != null)
			{
				var index = basket.ShoppingBasketItems.FindIndex(x => x.ProductId == basketItem.ProductId);
				if (index < 0)
				{
					basket.ShoppingBasketItems.Add(new ShoppingBasketItem
					{
						ProductId = basketItem.ProductId,
						Quantity = basketItem.Quantity,
						ShoppingBasketId = basket.Id
					});
				}
				else
				{
					basket.ShoppingBasketItems[index].Quantity += basketItem.Quantity;
				}
				await _shoppingBasketRepository.UpdateAsync(basket);
				return Response<NoContent>.Success(200);
			}
			return Response<NoContent>.Fail(500,"Bir hata oluştu");
		}

		public async Task<Response<List<ShoppingBasketItem>>> GetBasketItemAsync()
		{
			ShoppingBasket? basket = await ContextUser();
			ShoppingBasket? result= await _shoppingBasketRepository.Table
				.Include(b=>b.ShoppingBasketItems)
				.ThenInclude(bi=>bi.Product)
				.FirstOrDefaultAsync(b=>b.Id == basket.Id);
			var shoppingBasketItems= result?.ShoppingBasketItems;
			return Response<List<ShoppingBasketItem>>.Success(shoppingBasketItems,200);
			
		}

		public async Task<Response<NoContent>> UpdateQuantityAsync(UpdateBasketItemViewModel basketItem)
		{
			ShoppingBasketItem? _basketItem = await _shoppingBasketItemRepository.GetAsync(bi => bi.Id == basketItem.BasketItemId);
			if(_basketItem != null)
			{
				_basketItem.Quantity=basketItem.Quantity;
				await _shoppingBasketItemRepository.UpdateAsync(_basketItem);
				return Response<NoContent>.Success(200);
			}
			return Response<NoContent>.Fail(500, "Bir sorun oluştu");
		}

		public async Task<Response<NoContent>> RemoveBasketItemAsync(int basketItemId)
		{
			ShoppingBasketItem? basketItem =await _shoppingBasketItemRepository.GetAsync(bi=>bi.Id==basketItemId);
			if (basketItem != null)
			{
				await _shoppingBasketItemRepository.HardDeleteAsync(basketItem);
				return Response<NoContent>.Success(200);
			}
			return Response<NoContent>.Fail(500,"Bir sorun oluştu");
		}
	}

		

		//public async Task<Response<NoContent>> CreateShoppingBasket()
		//{
		//	var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
		//	if (user != null)
		//	{
		//		var userId = await _userManager.GetUserIdAsync(user);
		//		var targetBasket = user.ShoppingBaskets.FirstOrDefault(basket => basket.Order == null);
		//		if (targetBasket == null)
		//		{

		//			targetBasket = new ShoppingBasket { UserId = user.Id };
		//			user.ShoppingBaskets.Add(targetBasket);
		//		}

				
		//		await _shoppingBasketRepository.CreateAsync(targetBasket);

		//		return Response<NoContent>.Success(200);
		//	}
		//	return  Response<NoContent>.Fail(500,"İşlem başarısız");

		//}
}

