using Microsoft.AspNetCore.Mvc.Rendering;
using RhythmicRealm.Shared.ViewModels.SubCategoryViewModels;
using System.ComponentModel;

namespace RhythmicRealm.UI.Areas.Admin.AdminViewModels
{
    public class AdminEditSubCategoryViewModel
    {
        public AdminEditSubCategoryViewModel()
        {
            MainCategoryList = new List<SelectListItem>();

        }
        public EditSubCategoryViewModel EditSubCategoryViewModel { get; set; }

        [DisplayName("Ana Kategori Seçiniz")]
        public List<SelectListItem>  MainCategoryList { get; set; }
        public  int MainCategoryId { get; set; }
        public string MainCategoryName { get; set; }
    }
}
