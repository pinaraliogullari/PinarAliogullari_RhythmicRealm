using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Data.Concrete.Contexts;
using RhythmicRealm.Entity.Concrete;

namespace RhythmicRealm.Data.Concrete.Repositories
{
	public class ShoppingBasketItemRepository : GenericRepository<ShoppingBasketItem>, IShoppingBasketItemRepository
	{
		public ShoppingBasketItemRepository(RRContext _context) : base(_context)
		{

		}
		private RRContext RRContext
		{
			get { return _dbContext as RRContext; }
		}

		public async Task UpdateQuantityAsync(ShoppingBasketItem shoppingBasketItem, int quantity)
		{
			shoppingBasketItem.Quantity = quantity;
			RRContext.Update(shoppingBasketItem);
			await RRContext.SaveChangesAsync();
		}
	}
}
