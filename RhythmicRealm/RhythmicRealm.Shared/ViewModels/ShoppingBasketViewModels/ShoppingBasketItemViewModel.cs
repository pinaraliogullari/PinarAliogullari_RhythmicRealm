using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Shared.ViewModels.ShoppingBasketViewModels
{
	public class ShoppingBasketItemViewModel
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public string ProductImageUrl { get; set; }
		public string ProductName { get; set; }
		public decimal ProductPrice { get; set; }
		public int Quantity { get; set; }
		public int ShoppingBasketId { get; set; }
		public ShoppingBasketViewModel ShoppingBasket { get; set; }
	}
}
