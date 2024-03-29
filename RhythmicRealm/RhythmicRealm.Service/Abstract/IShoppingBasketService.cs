using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.ShoppingBasketViewModels;


namespace RhythmicRealm.Service.Abstract
{
	public interface IShoppingBasketService
	{
		Task<Response<NoContent>> InitializeBasketAsync(string userId);
		Task<Response<ShoppingBasketViewModel>> GetShoppingBasketByUserId(string userId);
		Task<Response<ShoppingBasketViewModel>> AddItemToBasketAsync(string userId, int productId, int quantity);
		Task<Response<NoContent>> RemoveItemFromBasketAsync(string userId,int productId);
		Task<Response<NoContent>> RemoveBasket(int cartId);
	}
}
