using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Entity.Concrete;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.ViewModels.BrandViewModels;
using RhythmicRealm.Shared.ViewModels.Others;
using RhythmicRealm.Shared.ViewModels.ProductViewModels;
using RhythmicRealm.Shared.ViewModels.SubCategoryViewModels;
using System.ComponentModel;
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
			TempData["MainCategoryId"] = id;
			var products = await _productService.GetProductsByMainCategoryIdAsync(id);
			var model = new StoreViewModel
			{
				Products = products.Data,
				Brands = await GetBrandsByMainCategoryId(id),
				SubCategories = await GetSubCategoriesByMainCategoryId(id)
			};
			if (model.Products != null && model.Products.Any())
			{
				return View(model);
			}
			else
			{
				ViewBag.ErrorMessage = "Aradığınız kriterlere uygun ürün bulunamadı.";
				return View();
			}


		}


		public async Task<IActionResult> FilterProducts(string[] subCategory, string[] brand)
		{
			if (!TempData.ContainsKey("MainCategoryId"))
			{
				return RedirectToAction("Index");
			}

			var mainCategoryId = (int)TempData["MainCategoryId"];
			var filteredProducts = await GetFilteredProducts(mainCategoryId, subCategory, brand);
			var model = new StoreViewModel
			{
				Products = filteredProducts,
				Brands = await GetBrandsByMainCategoryId(mainCategoryId),
				SubCategories =await GetSubCategoriesByMainCategoryId(mainCategoryId)
			};
			
			return View("Index", model);
			
		
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

		private async Task<List<BrandSlimViewModel>> GetBrandsByMainCategoryId(int id)
		{
			var brands = await _brandService.GetBrandsByMainCategoryId(id);
			return brands.Data;
		}

		private async Task<List<InSubCategoryViewModel>> GetSubCategoriesByMainCategoryId(int id)
		{
			var subCategories = await _subCategoryService.GetSubCategoriesByMainCategoryId(id);
			return subCategories.Data;
		}



	}
}
