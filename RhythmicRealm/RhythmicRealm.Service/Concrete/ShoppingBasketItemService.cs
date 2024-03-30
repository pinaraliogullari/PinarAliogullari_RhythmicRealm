using Microsoft.EntityFrameworkCore;
using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Service.Abstract;


namespace RhythmicRealm.Service.Concrete
{
	public class ShoppingBasketItemService : IShoppingBasketItemService
	{
		private readonly IShoppingBasketItemRepository _shoppingBasketItemRepository;

		public ShoppingBasketItemService(IShoppingBasketItemRepository shoppingBasketItemRepository)
		{
			_shoppingBasketItemRepository = shoppingBasketItemRepository;
		}

		public async Task<int> CountAsync(int shoppingBasketId)
		{
			return await _shoppingBasketItemRepository.GetCount(x =>x.ShoppingBasketId==shoppingBasketId);
		}
	}
}

