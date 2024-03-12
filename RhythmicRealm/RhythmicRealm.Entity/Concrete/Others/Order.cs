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
		public string OrderNumber { get; set; }
		public DateTime OrderDate { get; set; } = DateTime.Now;
		public string UserId { get; set; }
		public User User { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string Note { get; set; }
		public PaymentOption PaymentType { get; set; }
		public OrderState OrderState { get; set; }
		public string ConversationId { get; set; }
		public string PaymentId { get; set; }
		public List<OrderDetails> OrderDetails { get; set; }
	}
}
