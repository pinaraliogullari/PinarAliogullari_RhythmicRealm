using RhythmicRealm.Entity.Concrete.Identity;

namespace RhythmicRealm.Entity.Concrete
{
	public class ShoppingBasket
	{
		public int Id { get; set; }
        public User	User { get; set; }
        public string UserId { get; set; }
        public List<ShoppingBasketItem> ShoppingBasketItems { get; set; }
      
    }
}
