using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.ViewModels.BrandViewModels;
using RhythmicRealm.Shared.ViewModels.Others;
using RhythmicRealm.Shared.ViewModels.ProductViewModels;
using RhythmicRealm.Shared.ViewModels.SubCategoryViewModels;

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
			TempData["MainCategoryId"] = id;
			var products = await _productService.GetProductsByMainCategoryIdAsync(id);
			var model = new StoreViewModel
			{
				Products = products.Data,
				Brands = await GetBrandsByMainCategoryId(id),
				SubCategories = await GetSubCategoriesByMainCategoryId(id)
			};
			

			return View(model);
		}
		public async Task<IActionResult> FilterProducts(int Id,int[] subCategoryId, int[] brandId)
		{
		

			var filteredProducts = await GetFilteredProducts(Id, subCategoryId, brandId);
			var model = new StoreViewModel
			{
				Products = filteredProducts,
				Brands = await GetBrandsByMainCategoryId(Id),
				SubCategories =await GetSubCategoriesByMainCategoryId(Id)
			};
			if (model.Products != null && model.Products.Any())
			{
				return View("Index", model);
			}
			else
			{
				ViewBag.ErrorMessage = "Aradığınız kriterlere uygun ürün bulunamadı.";
				return View("Index", model);

			}
		}

		private async Task<List<ProductViewModel>> GetFilteredProducts(int mainCategoryId, int[] subCategoryId, int[] brandId)
		{

			var products = await _productService.GetProductsBySubcategoryIdAndBrandId(mainCategoryId, subCategoryId, brandId);
			var data = products.Data;
			return data;
		}

		private async Task<List<BrandSlimViewModel>> GetBrandsByMainCategoryId(int id)
		{
			var brands = await _brandService.GetBrandsByMainCategoryIdAsync(id);
			return brands.Data;
		}

		private async Task<List<InSubCategoryViewModel>> GetSubCategoriesByMainCategoryId(int id)
		{
			var subCategories = await _subCategoryService.GetSubCategoriesByMainCategoryId(id);
			return subCategories.Data;
		}
		public async Task<IActionResult> ShowProducts(int id)
		{
			var products = await _productService.GetProductsByBrandIdAsync(id);
			var model = products.Data;
			return View(model);
		}
		public async Task<IActionResult> Search(string query)
		{

			string lowerCaseQuery = query?.ToLower(); 

			if (string.IsNullOrEmpty(lowerCaseQuery))
				lowerCaseQuery = TempData["LastSearchQuery"] as string;
			
			else
				TempData["LastSearchQuery"] = lowerCaseQuery;
			var searchResults = await _productService.SearchProductAsync(lowerCaseQuery);
			var model = searchResults.Data;
			return View(model);
		}

		public async Task<IActionResult> ShowProductsOnCards(int id)
		{
			if (id == 1)
			{
				var products = await _productService.GetNewProductsAsync();
				var model = products.Data;
				return View("ShowProducts",model);
			}

			if (id == 2)
			{
				var products = await _productService.GetAdvantageousProductsAsync();
				var model = products.Data;
				return View("ShowProducts", model);
			}
			if (id == 3)
			{
				var products = await _productService.GetSelectedProducts();
				var model = products.Data;
				return View("ShowProducts", model);
			}


			return View();
			
		}

		public async Task<IActionResult> StoreWithAllProducts()
		{
			var products= await _productService.GetAllProductsAsync();
			return View("ShowProducts", products.Data);
		}

	
	}
}
