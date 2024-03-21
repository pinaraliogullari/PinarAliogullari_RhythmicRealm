using Mapster;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.ViewModels.BrandViewModels;
using RhythmicRealm.Shared.ViewModels.ProductViewModels;
using RhythmicRealm.Shared.ViewModels.SubCategoryViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RhythmicRealm.UI.Areas.Admin.AdminViewModels;
using AspNetCoreHero.ToastNotification.Abstractions;
using RhythmicRealm.Shared.Helpers.Abstract;
using RhythmicRealm.Shared.Helpers.Concrete;
using Microsoft.AspNetCore.Authorization;



namespace RhythmicRealm.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
		private readonly IProductService _productService;
		private readonly IBrandService _brandService;
		private readonly ISubCategoryService _subCategoryService;
        private readonly IImageHelper _imageHelper;
        private readonly INotyfService _notyfService;

        public ProductController(IProductService productService, IBrandService brandService, ISubCategoryService subCategoryService, INotyfService notyfService, IImageHelper imageHelper)
        {
            _productService = productService;
            _brandService = brandService;
            _subCategoryService = subCategoryService;
            _notyfService = notyfService;
            _imageHelper = imageHelper;
        }

        [HttpGet]
        public async Task<IActionResult> Index(bool isdeleted)
        {
			var products = await _productService.GetProductsByIsDeleteAsync(isdeleted);

			ViewBag.TransferInf = isdeleted; 
		    TempData["TransferInf"] = isdeleted;
			return View(products.Data);

		}

		[Authorize(Roles = "SuperAdmin,Admin")]
		[HttpGet]
        public async Task<IActionResult> UpdateIsHome(int id)
        {
            var result = await _productService.UpdateIsHomeAsync(id);
            return Json(result);
        }


		[Authorize(Roles = "SuperAdmin,Admin")]
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


		[Authorize(Roles = "SuperAdmin,Admin")]
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
		public async Task<IActionResult> Edit(AdminEditProductViewModel adminEditProductViewModel, IFormFile image)
		{
            ModelState.Remove("Image");
            if (ModelState.IsValid )
            {
                if(image!=null)
                {
                    adminEditProductViewModel.EditProductViewModel.ImageUrl = await _imageHelper.UploadImage(image, "products");
                }
                adminEditProductViewModel.EditProductViewModel.Url = UrlCreateHelper.GetUrl(adminEditProductViewModel.EditProductViewModel.Name);

                var editProductViewModel = new EditProductViewModel
                {
                 
                    Id = adminEditProductViewModel.EditProductViewModel.Id,
                    Name = adminEditProductViewModel.EditProductViewModel.Name,
                    Description = adminEditProductViewModel.EditProductViewModel.Description,
                    ImageUrl = adminEditProductViewModel.EditProductViewModel.ImageUrl,
                    Url = adminEditProductViewModel.EditProductViewModel.Url,
                    Price = adminEditProductViewModel.EditProductViewModel.Price,
                    Properties = adminEditProductViewModel.EditProductViewModel.Properties,
                    IsHome = adminEditProductViewModel.EditProductViewModel.IsHome,
                    BrandId = adminEditProductViewModel.BrandId,
                    SubCategoryId = adminEditProductViewModel.SubCategoryId
                };
                await _productService.UpdateProductAsync(editProductViewModel);
                _notyfService.Success("Ürün başarıyla güncellendi");
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
            _notyfService.Error("Ürün güncellenirken bir sorun oluştu.");
            return View(adminEditProductViewModel);

        }


		[Authorize(Roles = "SuperAdmin,Admin")]
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


		[Authorize(Roles = "SuperAdmin,Admin")]
		[HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {
            await _productService.HardDeleteAsync(id);
            _notyfService.Error("Ürün kalıcı olarak silindi.");
            return RedirectToAction("Index");
            
        }


		[Authorize(Roles = "SuperAdmin,Admin")]
		[HttpGet]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _productService.SoftDeleteAsync(id);
            var tempdataInf = TempData["TransferInf"];
            if (tempdataInf != null && tempdataInf is bool transferInf && transferInf == true)

                _notyfService.Information("Ürün çöp kutusundan çıkartıldı.");

            else
                _notyfService.Information("Ürün çöp kutusuna gönderildi.");
            
            return RedirectToAction("Index", new { isdeleted = tempdataInf });
        }

		[Authorize(Roles = "SuperAdmin,Admin")]
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

        [HttpPost]
        public async Task<IActionResult> Create(AdminAddProductViewModel adminAddProductViewModel,IFormFile image)
        {
            ModelState.Remove("AddProductViewModel.ImageUrl");
            if (ModelState.IsValid && image!=null)
            {
                adminAddProductViewModel.AddProductViewModel.ImageUrl=await _imageHelper.UploadImage(image,"products");
                adminAddProductViewModel.AddProductViewModel.Url = UrlCreateHelper.GetUrl(adminAddProductViewModel.AddProductViewModel.Name);
                var model = new AddProductViewModel
                {
                    Name = adminAddProductViewModel.AddProductViewModel.Name,
                    Url = adminAddProductViewModel.AddProductViewModel.Url,
                    ImageUrl = adminAddProductViewModel.AddProductViewModel.ImageUrl,
                    Description = adminAddProductViewModel.AddProductViewModel.Description,
                    Properties = adminAddProductViewModel.AddProductViewModel.Properties,
                    IsActive = adminAddProductViewModel.AddProductViewModel.IsActive,
                    IsHome = adminAddProductViewModel.AddProductViewModel.IsHome,
                    Price=adminAddProductViewModel.AddProductViewModel.Price,
                    BrandId=adminAddProductViewModel.BrandId,
                    SubCategoryId=adminAddProductViewModel.SubCategoryId
                };
                await _productService.CreateProductAsync(model);
                _notyfService.Success("Ürün başarıyla kaydedildi.");
                return RedirectToAction("Index");
            }
            var brands = await GetBrandsAsync();
            var brandListItem = brands.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            }).ToList();
            adminAddProductViewModel.BrandList = brandListItem;

            var subCategories = await GetSubCategoriesAsync();
            var subCategoryListItem = subCategories.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            }).ToList();
            adminAddProductViewModel.SubCategoryList = subCategoryListItem;
            _notyfService.Error("Ürün kaydedilirken bir sorun oluştu.");
            return View(adminAddProductViewModel);
        }


    }


}

