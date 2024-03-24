﻿using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.ViewModels.ProductViewModels;

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

		public async Task<IActionResult> Index(int id,int brandId,int subCategoryId)
        {
			var products=await GetProductsByMainCategoryIdAsync(id);
            return View(products);
        }

        private async Task<List<ProductViewModel>> GetProductsByMainCategoryIdAsync(int id)
        {
			var products = await _productService.GetProductsByMainCategoryIdAsync(id);
			return products.Data.ToList();

		}

	

	}
}
