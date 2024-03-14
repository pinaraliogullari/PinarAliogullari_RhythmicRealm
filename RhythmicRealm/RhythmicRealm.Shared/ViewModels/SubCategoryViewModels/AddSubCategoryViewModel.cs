using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RhythmicRealm.Shared.ViewModels.MainCategoryViewModels;

namespace RhythmicRealm.UI.ViewModels.SubCategoryViewModels
{
    public class AddSubCategoryViewModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Url { get; set; }
        public MainCategorySlimViewModel MainCategories { get; set; }
    }
}
