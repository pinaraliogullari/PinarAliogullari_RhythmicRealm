using RhythmicRealm.Shared.ViewModels.BrandViewModels;
using RhythmicRealm.Shared.ViewModels.ProductViewModels;
using RhythmicRealm.Shared.ViewModels.SubCategoryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Shared.ViewModels.Others
{
	public class StoreViewModel
	{
        public List<ProductViewModel> Products { get; set; }
        public List<BrandSlimViewModel>  Brands { get; set; }
        public List<InSubCategoryViewModel> SubCategories { get; set; }
    }
}
