using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.ViewModels.ProductViewModels;
using System.Linq;

namespace RhythmicRealm.UI.Controllers
{
    public class StoreController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly IBrandService _brandService;
        private readonly IProductService _productService;

		public StoreController(ISubCategoryService subCategoryService, IBrandService brandService, IProductService productService)
		{
			_subCategoryService = subCategoryService;
			_brandService = brandService;
			_productService = productService;
		}

		public async Task<IActionResult> Index(int id)
        {
			var products=await GetProductsByMainCategoryIdAsync(id);
			TempData["mainCategoryId"] = id;
			return View(products);
		
        }

        private async Task<List<ProductViewModel>> GetProductsByMainCategoryIdAsync(int id)
        {
			var products = await _productService.GetProductsByMainCategoryIdAsync(id);
			return products.Data.ToList();

		}
		
		public async Task<IActionResult> FilterProducts(string[] subCategory, string[] brand)
		{
			var mainCategoryId = (int)TempData["mainCategoryId"];
			var filteredProducts = await GetFilteredProducts(mainCategoryId, subCategory, brand);



			return View("Index",filteredProducts);
		}

		private async Task<List<ProductViewModel>> GetFilteredProducts(int mainCategoryId, string[] subCategory, string[] brand)
		{
			var products = await _productService.GetProductsByMainCategoryIdAsync(mainCategoryId);
			var data = products.Data;

			if (subCategory != null && subCategory.Length > 0)
			{
				data = data.Where(p => subCategory.Contains(p.SubCategory.Name)).ToList();
			}

			if (brand != null && brand.Length > 0)
			{
				data = data.Where(p => brand.Contains(p.Brand.Name)).ToList();
			}

			return data;
		}



	}
}
