using RhythmicRealm.Entity.Concrete;

namespace RhythmicRealm.Data.Abstract
{
    public interface IShoppingBasketItemRepository : IGenericRepository<ShoppingBasketItem>
	{
		Task UpdateQuantityAsync(ShoppingBasketItem shoppingBasketItem, int quantity);
	}
}
