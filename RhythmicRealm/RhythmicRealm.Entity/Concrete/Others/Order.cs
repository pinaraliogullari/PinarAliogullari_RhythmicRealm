using RhythmicRealm.Entity.Concrete.Identity;
using RhythmicRealm.Shared.ComplexTypes;

namespace RhythmicRealm.Entity.Concrete
{
	public class Order
	{
        public Order()
        {
            OrderItems=new List<OrderItem>();
        }

        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }=DateTime.Now;
        public string UserId { get; set; }
        public User User { get; set; }
        public EnumOrderState OrderState { get; set; }
        public EnumPaymentOptions PaymentOptions { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string OrderNote { get; set; }
        public string PaymentId { get; set; }
        public string PaymentToken { get; set; }
        public string ConversationId { get; set; }
        public List<OrderItem> OrderItems { get; set; }

    }
}
