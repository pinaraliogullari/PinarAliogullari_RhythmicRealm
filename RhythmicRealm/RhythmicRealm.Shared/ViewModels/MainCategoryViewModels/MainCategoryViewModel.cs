﻿using RhythmicRealm.Shared.ViewModels.SubCategoryViewModels;

namespace RhythmicRealm.Shared.ViewModels.MainCategoryViewModels
{
	public class MainCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Url { get; set; }
        public List<InSubCategoryViewModel> SubCategories { get; set; }
    }
}
