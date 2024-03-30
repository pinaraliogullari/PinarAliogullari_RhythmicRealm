using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Data.Concrete.Contexts;
using RhythmicRealm.Entity.Concrete;
using RhythmicRealm.Entity.Concrete.Identity;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.ShoppingBasketViewModels;


namespace RhythmicRealm.Service.Concrete
{
	public class ShoppingBasketService : IShoppingBasketService
	{
		private readonly UserManager<User> _userManager;
		private readonly IShoppingBasketRepository _shoppingBasketRepository;
        private readonly IHttpContextAccessor _contextAccessor;

		public ShoppingBasketService(UserManager<User> userManager, IShoppingBasketRepository shoppingBasketRepository, IHttpContextAccessor contextAccessor)
		{
			_userManager = userManager;
			_shoppingBasketRepository = shoppingBasketRepository;
			_contextAccessor = contextAccessor;
		}

		public async Task<Response<ShoppingBasketViewModel>> AddItemToBasketAsync(string userId, int productId, int quantity)
        {
            var basket=await _shoppingBasketRepository.GetShoppingBasketByUserIdAsync(userId);
            if (basket != null)
            {
                var index= basket.ShoppingBasketItems.FindIndex(x=> x.ProductId == productId);
                if (index <0)
                {
                    basket.ShoppingBasketItems.Add(new ShoppingBasketItem
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        ShoppingBasketId = basket.Id,
                       
                    });
                }
                else
                {
                    basket.ShoppingBasketItems[index].Quantity += quantity;
                }
                await _shoppingBasketRepository.UpdateAsync(basket);
              
                return Response<ShoppingBasketViewModel>.Success(200);

            }
            return Response<ShoppingBasketViewModel>.Fail(500,"Bir hata meydana geldi");
        }

	

		public async Task<Response<ShoppingBasketViewModel>> GetShoppingBasketByUserIdAsync(string userId)
        {
           var basket= await _shoppingBasketRepository.GetShoppingBasketByUserIdAsync(userId);
            var basketViewModel = new ShoppingBasketViewModel
            {
                ShoppingBasketId = basket.Id,
                BasketItems = basket.ShoppingBasketItems.Select(item => new ShoppingBasketItemViewModel
                {
                    BasketItemId = item.Id,
                    ProductId = item.ProductId,
                    Name = item.Product.Name,
                    Price = item.Product.Price,
                    ImageUrl = item.Product.ImageUrl,
                    Quantity = item.Quantity
                }).ToList()
            };

			if (basketViewModel == null)
                return Response<ShoppingBasketViewModel>.Fail(404, "Sonuç bulunamadı");
            else
                return Response<ShoppingBasketViewModel>.Success(basketViewModel, 200);
        }

        public async Task<Response<NoContent>> InitializeBasketAsync(string userId)
        {
            await _shoppingBasketRepository.CreateAsync(new ShoppingBasket() { UserId = userId });
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<NoContent>> RemoveItemFromBasketAsync(string userId, int productId)
        {
            var basket = await GetShoppingBasketByUserIdAsync(userId);
            if (basket != null)
            {
                await _shoppingBasketRepository.DeleteFromShoppingBasketAsync(basket.Data.ShoppingBasketId, productId);
                return Response<NoContent>.Success(200);
            }
                return Response<NoContent>.Fail(500, "Bir hata meydana geldi");

        }

		public async Task<Response<ShoppingBasketViewModel>> UpdateQuantityAsync(int shoppingBasketItemId, int quantity,string userId)
		{
		    await _shoppingBasketRepository.UpdateQuantityAsync(shoppingBasketItemId, quantity);
            await _shoppingBasketRepository.GetShoppingBasketByUserIdAsync(userId);
            return Response<ShoppingBasketViewModel>.Success(200);
           
		}

		//public async Task<Response<NoContent>> RemoveBasketAsync(int cartId)
		//{
		//    await _shoppingBasketRepository.ClearShoppingBasketAsync(cartId);
		//    return Response<NoContent>.Success(200);
		//}

	}
}

