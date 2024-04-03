using RhythmicRealm.Shared.ViewModels.MainCategoryViewModels;

namespace RhythmicRealm.Shared.ViewModels.BrandViewModels
{
	public class BrandViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public List<MainCategoryViewModel> MainCategories { get; set; }
    }
}
