using RhythmicRealm.Shared.ViewModels.MainCategoryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.UI.ViewModels.SubCategoryViewModels
{
    public class EditSubCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Url { get; set; }
        public MainCategorySlimViewModel MainCategories { get; set; }
    }
}
