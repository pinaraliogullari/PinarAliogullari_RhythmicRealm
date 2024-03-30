using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Service.Abstract;

namespace RhythmicRealm.UI.ViewComponents
{
	public class RelatedProductsViewComponent:ViewComponent
	{
		private readonly IProductService _productService;

		public RelatedProductsViewComponent(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<IViewComponentResult> InvokeAsync(int subCategoryId)
		{
			var products = await _productService.GetProductsBySubCategoryIdAsync(subCategoryId);
			var model = products.Data;
			return View(model);
		}
	}
}
