using Microsoft.AspNetCore.Mvc.Rendering;
using RhythmicRealm.Shared.ViewModels.ProductViewModels;
using System.ComponentModel;

namespace RhythmicRealm.UI.Areas.Admin.AdminViewModels
{
    public class AdminEditProductViewModel
    {
        public AdminEditProductViewModel()
        {
            BrandList = new List<SelectListItem>();
            SubCategoryList = new List<SelectListItem>();

        }
        public EditProductViewModel EditProductViewModel { get; set; }

        [DisplayName("Marka Listesi")]
        public List<SelectListItem> BrandList { get; set; }

        public int BrandId { get; set; }

        public int SubCategoryId { get; set; }


        [DisplayName("Alt Kategori Seçiniz")]
        public List<SelectListItem> SubCategoryList { get; set; } 
    }
}
