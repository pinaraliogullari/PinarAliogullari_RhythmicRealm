using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Service.Abstract;


namespace RhythmicRealm.Service.Concrete
{
	public class ShoppingBasketItemService : IShoppingBasketItemService
	{
		private readonly IShoppingBasketRepository _shoppingBasketRepository;

		public ShoppingBasketItemService(IShoppingBasketRepository shoppingBasketRepository)
		{
			_shoppingBasketRepository = shoppingBasketRepository;
		}

		public async Task<int> CountAsync(int shoppingBasketId)
		{
			return await _shoppingBasketRepository.GetCount(x => x.Id == shoppingBasketId);
		}
	}
}

