using Microsoft.EntityFrameworkCore;
using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Data.Concrete.Contexts;
using RhythmicRealm.Entity.Concrete;


namespace RhythmicRealm.Data.Concrete.Repositories
{
	public class ShoppingBasketRepository:GenericRepository<ShoppingBasket>,IShoppingBasketRepository
	{
		public ShoppingBasketRepository(RRContext _context) : base(_context)
		{

		}
		private RRContext RRContext
		{
			get { return _dbContext as RRContext; }
        }

        
        public async Task ClearShoppingBasketAsync(int shoppingBasketId)
        {
            var deletedItems= await RRContext
                .ShoppingBasketItems
                .Where(x=>x.ShoppingBasketId==shoppingBasketId)
                .ToListAsync();
            RRContext.ShoppingBasketItems.RemoveRange(deletedItems);
            await RRContext.SaveChangesAsync();
        }

        public async Task DeleteFromShoppingBasketAsync(int shoppingBasketId, int productId)
        {
            var deletedItem = await RRContext
                .ShoppingBasketItems
                .Where(x => x.ShoppingBasketId == shoppingBasketId && x.ProductId == productId)
                .FirstOrDefaultAsync();
            RRContext.ShoppingBasketItems.Remove(deletedItem);
            await RRContext.SaveChangesAsync();
        }

        public async Task<ShoppingBasket> GetShoppingBasketByUserIdAsync(string userId)
        {

            var shoppingBasket = await RRContext
                .ShoppingBaskets
                .Include(x => x.ShoppingBasketItems)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.UserId == userId);
            return shoppingBasket;


        }

		public async Task UpdateQuantityAsync(int shoppingBasketItemId, int quantity)
		{
			var updatedItem = await RRContext.ShoppingBasketItems.FindAsync(shoppingBasketItemId);
				updatedItem.Quantity = quantity;
				await RRContext.SaveChangesAsync();
			
		}
	}
}
