﻿using RhythmicRealm.Shared.ViewModels.MainCategoryViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RhythmicRealm.Shared.ViewModels.SubCategoryViewModels
{
	public class AddSubCategoryViewModel
    {
        [DisplayName("Alt Kategori Adı")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı uzunluğu {1} karakterden az girilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} alanı uzunluğu {1} karakterden bçok girilmemelidir.")]
        public string Name { get; set; }
        public bool IsActive { get; set; }

        [DisplayName("Url")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı uzunluğu {1} karakterden az girilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} alanı uzunluğu {1} karakterden bçok girilmemelidir.")]
        public string Url { get; set; }
        public MainCategorySlimViewModel MainCategories { get; set; }

        public int MainCategoryId { get; set; }
    }
}
