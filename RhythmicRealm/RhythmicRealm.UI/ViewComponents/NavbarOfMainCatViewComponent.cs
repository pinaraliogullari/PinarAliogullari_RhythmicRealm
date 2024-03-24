using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.ViewModels.BrandViewModels;

namespace RhythmicRealm.UI.ViewComponents
{
	public class NavbarOfMainCatViewComponent:ViewComponent
	{
		private readonly IMainCategoryService _mainCategoryService;

		public NavbarOfMainCatViewComponent(IMainCategoryService mainCategoryService)
		{
			_mainCategoryService = mainCategoryService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var mainCategories = await _mainCategoryService.GetMainCategoriesByIsActiveAsync();
			var model = mainCategories.Data;
			return View(model);
		}
	}
}
