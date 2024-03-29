
namespace RhythmicRealm.Shared.ViewModels.ShoppingBasketViewModels
{
    public partial class ShoppingBasketViewModel
    {
        public int ShoppingBasketId { get; set; }
        public List<ShoppingBasketItemViewModel> BasketItems { get; set; }

        public decimal TotalPrice()
        {
            return BasketItems.Sum(x => x.Price * x.Quantity);
        }

    }

    public class ShoppingBasketItemViewModel
    {
        public int BasketItemId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
	}
}

