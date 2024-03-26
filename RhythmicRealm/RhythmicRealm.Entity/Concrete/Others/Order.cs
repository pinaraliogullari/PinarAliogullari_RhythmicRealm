using RhythmicRealm.Entity.Concrete.Identity;
using RhythmicRealm.Shared.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Entity.Concrete
{
	public class Order
	{
		public int Id { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public string UserId { get; set; }
		public User User { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public ShoppingBasket ShoppingBasket { get; set; }
        public List<Product> Products { get; set; }

		//public PaymentOption PaymentType { get; set; }
		//public OrderState OrderState { get; set; }
		//public string ConversationId { get; set; }
		//public string PaymentId { get; set; }
	}
}
