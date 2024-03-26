using RhythmicRealm.Entity.Concrete;
using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.MainCategoryViewModels;
using RhythmicRealm.Shared.ViewModels.ShoppingBasketViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Service.Abstract
{
	public interface IShoppingBasketService
	{
		Task<Response<List<ShoppingBasketItem>>> GetBasketItemAsync();
		Task<Response<NoContent>> AddItemToBasketAsync(CreateBasketItemViewModel basketItem);
		Task<Response<NoContent>> UpdateQuantityAsync(UpdateBasketItemViewModel basketItem);
		Task<Response<NoContent>> RemoveBasketItemAsync(int basketItemId);
		//Task<Response<NoContent>> CreateShoppingBasket();
	}
}
