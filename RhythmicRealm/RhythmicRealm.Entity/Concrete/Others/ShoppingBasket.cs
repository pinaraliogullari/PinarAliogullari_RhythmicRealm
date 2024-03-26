using RhythmicRealm.Entity.Abstract;
using RhythmicRealm.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Entity.Concrete
{
	public class ShoppingBasket:IMainEntity
	{
		public int Id { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public User	User { get; set; }
        public string UserId { get; set; }
        public Order Order { get; set; }
        public List<ShoppingBasketItem> ShoppingBasketItems { get; set; }

    }
}
