using Microsoft.AspNetCore.Mvc.Rendering;
using RhythmicRealm.Shared.ViewModels.SubCategoryViewModels;
using System.ComponentModel;

namespace RhythmicRealm.UI.Areas.Admin.AdminViewModels
{
    public class AdminAddSubCategoryViewModel
    {
        public AdminAddSubCategoryViewModel()
        {
            MainCategoryList = new List<SelectListItem>();

        }
        public AddSubCategoryViewModel AddSubCategoryViewModel { get; set; }

        [DisplayName("Ana Kategori Seçiniz")]
        public List<SelectListItem>  MainCategoryList { get; set; }
        public  int MainCategoryId { get; set; }
        public string MainCategoryName { get; set; }
    }
}
