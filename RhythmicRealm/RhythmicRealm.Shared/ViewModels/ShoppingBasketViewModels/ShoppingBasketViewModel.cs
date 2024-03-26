using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Shared.ViewModels.ShoppingBasketViewModels
{
	public class ShoppingBasketViewModel
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public List<ShoppingBasketItemViewModel> ShoppingBasketItems { get; set; }

		//public decimal TotalPrice()
		//{
		//	return ShoppingBasketItems.Sum(x => x.ProductPrice * x.Quantity);
		//}

	}
}
