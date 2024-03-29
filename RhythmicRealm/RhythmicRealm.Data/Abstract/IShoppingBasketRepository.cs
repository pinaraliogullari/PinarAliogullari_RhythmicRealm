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
        Task DeleteFromShoppingBasketAsync(int shoppingCartId, int productId);
        Task ClearShoppingBasketAsync(int shoppingCartId);

    }
}
