using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.ShoppingBasketViewModels;

namespace RhythmicRealm.Service.Abstract
{
	public interface IShoppingBasketItemService
	{
		Task<int> CountAsync(int shoppingBasketId);
		Task<Response<ShoppingBasketItemViewModel>> UpdateQuantityAsync(int shoppingCartItemId, int quantity);
	
	}
}
