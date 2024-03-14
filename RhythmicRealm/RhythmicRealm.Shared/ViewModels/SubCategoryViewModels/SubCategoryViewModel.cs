using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RhythmicRealm.Shared.ViewModels.BrandViewModels;
using RhythmicRealm.Shared.ViewModels.ProductViewModels;

namespace RhythmicRealm.UI.ViewModels.SubCategoryViewModels
{
    public class SubCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Url { get; set; }
        public List<InProductViewModel> Products { get; set; }
        public List<BrandSlimViewModel> Brands { get; set; }
    }
}
