using Microsoft.EntityFrameworkCore;
using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.ShoppingBasketViewModels;


namespace RhythmicRealm.Service.Concrete
{
	public class ShoppingBasketItemService : IShoppingBasketItemService
	{
		private readonly IShoppingBasketItemRepository _shoppingBasketItemRepository;

		public ShoppingBasketItemService(IShoppingBasketItemRepository shoppingBasketItemRepository)
		{
			_shoppingBasketItemRepository = shoppingBasketItemRepository;
		}

		public async Task<Response<NoContent>> UpdateQuantityAsync(int shoppingBasketItemId, int quantity)
		{
			var shoppingBasketItem = await _shoppingBasketItemRepository.GetAsync(x => x.Id == shoppingBasketItemId);

			if (shoppingBasketItem == null)
				return Response<NoContent>.Fail(500,"Bir hata meydana geldi"); 
			shoppingBasketItem.Quantity = quantity; 
			await _shoppingBasketItemRepository.UpdateAsync(shoppingBasketItem);
			return Response<NoContent>.Success(200); 
		}

		public async Task<int> CountAsync(int shoppingBasketId)
		{
			return await _shoppingBasketItemRepository.GetCount(x =>x.ShoppingBasketId==shoppingBasketId);
		}

		public async Task<Response<ShoppingBasketItemViewModel>> GetShoppingBasketItemAsync(int shoppingBasketItemId)
		{
			var shoppingBasketItem= await _shoppingBasketItemRepository.GetAsync(x=>x.Id==shoppingBasketItemId,IncludeExpression=>IncludeExpression
			.Include(x=>x.Product));
			var shoppingBasketItemViewModel = new ShoppingBasketItemViewModel
			{
				BasketItemId = shoppingBasketItemId,
				ProductId = shoppingBasketItem.ProductId,
				ImageUrl = shoppingBasketItem.Product.ImageUrl,
				Price = shoppingBasketItem.Product.Price,
				Name = shoppingBasketItem.Product.Name,
				Quantity = shoppingBasketItem.Quantity
			};
			return Response<ShoppingBasketItemViewModel>.Success(shoppingBasketItemViewModel,200);
		}
	}
}

