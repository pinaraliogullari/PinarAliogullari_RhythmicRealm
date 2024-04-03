using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Service.Abstract;

namespace RhythmicRealm.UI.ViewComponents
{
	public class SearchBarViewComponent:ViewComponent
	{
		private readonly IProductService _productService;

		public SearchBarViewComponent(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
		
	}
}
