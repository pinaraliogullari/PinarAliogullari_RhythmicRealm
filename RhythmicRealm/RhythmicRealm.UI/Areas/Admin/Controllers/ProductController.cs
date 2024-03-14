using Mapster;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.ViewModels.BrandViewModels;
using RhythmicRealm.Shared.ViewModels.ProductViewModels;
using RhythmicRealm.UI.ViewModels.SubCategoryViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RhythmicRealm.UI.Areas.Admin.AdminViewModels;
using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.SubCategoryViewModels;



namespace RhythmicRealm.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
		private readonly IProductService _productService;
		private readonly IBrandService _brandService;
		private readonly ISubCategoryService _subCategoryService;

        public ProductController(IProductService productService, IBrandService brandService, ISubCategoryService subCategoryService)
        {
            _productService = productService;
            _brandService = brandService;
            _subCategoryService = subCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(bool isdeleted)
        {
			var products = await _productService.GetProductsByIsDeleteAsync(isdeleted);

			ViewBag.TransferInf = isdeleted; 
		    TempData["TransferInf"] = isdeleted;

			return View(products.Data);

		}
		[HttpGet]
        public async Task<IActionResult> UpdateIsHome(int id)
        {
            var result = await _productService.UpdateIsHomeAsync(id);
            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            var result = await _productService.UpdateIsActiveAsync(id);
            return Json(result);

        }

        private async Task<ProductViewModel> GetProductAsync(int id)
		{
			var product= await _productService.GetProductByProductIdAsync(id);
			return product.Data;
		}

		private async Task<List<BrandViewModel>> GetBrandsAsync()
		{
			var brands= await _brandService.GetAllBrandsAsync();
			//var brandSlimViewModel=brands.Adapt<List<BrandSlimViewModel>>();
			return brands.Data;
		}

		private async Task<List<SubCategoryViewModel>> GetSubCategoriesAsync()
		{
			var subCategories= await _subCategoryService.GetAllSubCategoriesAsync();
			//var subCategorySlimViewModel=subCategories.Adapt<List<SubCategorySlimViewModel>>();
			return subCategories.Data;
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
            ProductViewModel product = await GetProductAsync(id);

            var brands = await GetBrandsAsync();
            var brandListItem = brands.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            }).ToList();


            var subCategories = await GetSubCategoriesAsync();
            var subCategoryListItem = subCategories.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            }).ToList();

            var model = new AdminEditProductViewModel()
            {
               EditProductViewModel = new EditProductViewModel
                {
                Id = product.Id,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                IsActive = product.IsActive,
                IsHome = product.IsHome,
                Name = product.Name,
                Url = product.Url,
                Properties = product.Properties,
                },
                BrandList = brandListItem,
                SubCategoryList = subCategoryListItem,
                BrandId = product.Brand.Id,
                SubCategoryId = product.SubCategory.Id
            };

            return View(model);

		}

		[HttpPost]
		public async Task<IActionResult> Edit(AdminEditProductViewModel adminEditProductViewModel)
		{
            
            if (ModelState.IsValid )
            {
                var editProductViewModel = new EditProductViewModel
                {
                    //editproductviewmodelin içinde brand, sub filan yok.
                    Id = adminEditProductViewModel.EditProductViewModel.Id,
                    Name = adminEditProductViewModel.EditProductViewModel.Name,
                    Description = adminEditProductViewModel.EditProductViewModel.Description,
                    ImageUrl = adminEditProductViewModel.EditProductViewModel.ImageUrl,
                    Url = adminEditProductViewModel.EditProductViewModel.Url,
                    Price = adminEditProductViewModel.EditProductViewModel.Price,
                    Properties = adminEditProductViewModel.EditProductViewModel.Properties,
                    IsHome = adminEditProductViewModel.EditProductViewModel.IsHome,

                };
                await _productService.UpdateProductAsync(editProductViewModel);
                return RedirectToAction("Index");
            }

            var brands = await GetBrandsAsync();
            var brandListItem = brands.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            }).ToList();
            adminEditProductViewModel.BrandList = brandListItem;

            var subCategories = await GetSubCategoriesAsync();
            var subCategoryListItem = subCategories.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            }).ToList();
            adminEditProductViewModel.SubCategoryList = subCategoryListItem;

            return View(adminEditProductViewModel);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProductByProductIdAsync(id);
            var productViewModel = product.Data;
            AdminDeleteProductViewModel model = new AdminDeleteProductViewModel
            {
                Id = productViewModel.Id,
                Name = productViewModel.Name,
                Price = productViewModel.Price,
                Description = productViewModel.Description,
            };
            return PartialView("_DeleteProductPartialView", model);
        }

        [HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {

            await _productService.HardDeleteAsync(id);
            return RedirectToAction("Index");
            
        }
     
        [HttpGet]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _productService.SoftDeleteAsync(id);
            var tempdataInf = TempData["TransferInf"];
            return RedirectToAction("Index", new { isdeleted = tempdataInf });
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var brands = await GetBrandsAsync();
            var brandListItem = brands.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            }).ToList();
            var subCategories = await GetSubCategoriesAsync();
            var subCategoryListItem = subCategories.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            }).ToList();
            AdminAddProductViewModel adminAddProductViewModel = new AdminAddProductViewModel
            {
                BrandList = brandListItem,
                SubCategoryList = subCategoryListItem,
            };

            return View(adminAddProductViewModel);
        }

        //[HttpPost]
        //public async Task<IActionResult>Create(AdminAddProductViewModel adminAddProductViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {

        //    }
        //}


    }


}

