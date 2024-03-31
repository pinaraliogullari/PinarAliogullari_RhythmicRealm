using RhythmicRealm.Shared.ViewModels.ShoppingBasketViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Shared.ViewModels.OrderViewModels
{
	public class OrderViewModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string CardName { get; set; }
		public string CardNumber { get; set; }
		public string ExpirationMonth { get; set; }
		public string ExpirationYear { get; set; }
		public string Cvc { get; set; }
		public ShoppingBasketViewModel ShoppingBasket { get; set; }
	}
}
