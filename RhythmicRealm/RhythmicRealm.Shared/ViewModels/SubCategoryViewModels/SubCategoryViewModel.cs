﻿using RhythmicRealm.Shared.ViewModels.BrandViewModels;
using RhythmicRealm.Shared.ViewModels.MainCategoryViewModels;
using RhythmicRealm.Shared.ViewModels.ProductViewModels;

namespace RhythmicRealm.Shared.ViewModels.SubCategoryViewModels
{
	public class SubCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Url { get; set; }
        public MainCategorySlimViewModel MainCategory { get; set; }
        public List<InProductViewModel> Products { get; set; }
        public List<BrandSlimViewModel> Brands { get; set; }
    }
}
