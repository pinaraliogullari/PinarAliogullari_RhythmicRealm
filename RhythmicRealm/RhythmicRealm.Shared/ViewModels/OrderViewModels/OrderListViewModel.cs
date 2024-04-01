using RhythmicRealm.Shared.ComplexTypes;
using RhythmicRealm.Shared.ViewModels.ProductViewModels;
namespace RhythmicRealm.Shared.ViewModels.OrderViewModels
{
	public class OrderListViewModel
	{
		public int Id { get; set; }
		public string OrderNumber { get; set; }
		public DateTime OrderDate { get; set; }=DateTime.Now;
		public EnumOrderState OrderState { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string PhoneNumber{ get; set; }
		public string Email { get; set; }
		public string OrderNote { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }
		public decimal TotalPrice()
		{
			return OrderItems.Sum(x => x.Price * x.Quantity);
		}

		public class OrderItemViewModel
		{
			public int Id { get; set; }
			public decimal Price { get; set; }
			public int Quantity { get; set; }
			public int ProductId { get; set; }
			public ProductViewModel Product { get; set; }
		}
    }
}
