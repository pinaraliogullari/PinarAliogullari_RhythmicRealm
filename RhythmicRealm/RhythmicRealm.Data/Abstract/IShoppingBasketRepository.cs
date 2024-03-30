using RhythmicRealm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Data.Abstract
{
	public interface IShoppingBasketRepository:IGenericRepository<ShoppingBasket>
	{
        Task<ShoppingBasket> GetShoppingBasketByUserIdAsync(string userId);
        Task DeleteFromShoppingBasketAsync(int shoppingBasketId, int productId);
        Task ClearShoppingBasketAsync(int shoppingBasketId);
        Task UpdateQuantityAsync(int shoppingBasketItemId, int quantity);

    }
}
