using RhythmicRealm.Shared.ViewModels.BrandViewModels;
using RhythmicRealm.Shared.ViewModels.ProductViewModels;
using RhythmicRealm.Shared.ViewModels.SubCategoryViewModels;

namespace RhythmicRealm.Shared.ViewModels.Others
{
	public class StoreViewModel
	{
        public List<ProductViewModel> Products { get; set; }
        public List<BrandSlimViewModel>  Brands { get; set; }
        public List<InSubCategoryViewModel> SubCategories { get; set; }
    }
}
