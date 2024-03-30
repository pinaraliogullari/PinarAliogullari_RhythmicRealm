using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.ShoppingBasketViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Service.Abstract
{
	public interface IShoppingBasketItemService
	{
		Task<int> CountAsync(int shoppingBasketId);
		Task<Response<ShoppingBasketItemViewModel>> UpdateQuantityAsync(int shoppingCartItemId, int quantity);
	
	}
}
