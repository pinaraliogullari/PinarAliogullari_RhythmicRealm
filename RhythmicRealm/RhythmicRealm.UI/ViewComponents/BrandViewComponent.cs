using Mapster;
using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.ViewModels.BrandViewModels;

namespace RhythmicRealm.UI.ViewComponents
{
    public class BrandViewComponent:ViewComponent
	{
		private readonly IBrandService _brandService;
	

		public BrandViewComponent(IBrandService brandService)
		{
			_brandService = brandService;
			
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var brands = await _brandService.GetAllBrandsAsync();
			var data = brands.Data;
			var model= data.Adapt<List<BrandSlimViewModel>>();

			return View(model);
		}
	}
}
