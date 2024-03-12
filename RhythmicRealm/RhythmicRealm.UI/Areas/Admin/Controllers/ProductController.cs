//using Mapster;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using RhythmicRealm.Service.Abstract;
//using RhythmicRealm.Shared.ViewModels;
//using System;
//using System.ComponentModel.DataAnnotations;
//using System.Security.Cryptography.X509Certificates;
//using System.Text.Json;

//namespace RhythmicRealm.UI.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    public class ProductController : Controller
//    {
//        private readonly IProductService _productService;

//		public ProductController(IProductService productService)
//		{
//			_productService = productService;
//		}

//		[HttpGet]
//        public async Task<IActionResult> Index(bool isdeleted)
//        {

//            var products= await _productService.
           
             
               
//        }
        

//            //ViewBag.TransferId = id; 
//           // TempData["TransferId"] = id;

//            return View(response.Data);
//        }

//        private async Task<ProductViewModel> GetProductAsync(int id)
//        {
//            Response<ProductViewModel> response = new Response<ProductViewModel>();
//            using (HttpClient httpclient = new HttpClient())
//            {
//                HttpResponseMessage responseApi = await httpclient.GetAsync($"https://localhost:7284/api/product/get-product/{id}");
//                string contentResponseApi = await responseApi.Content.ReadAsStringAsync();
//                response = JsonSerializer.Deserialize<Response<ProductViewModel>>(contentResponseApi);
//            }

//            return response.Data;
//        }

//        private async Task<List<BrandSlimViewModel>> GetBrandsAsync()
//        {
//            Response<List<BrandSlimViewModel>> response = new Response<List<BrandSlimViewModel>>();
//            using (HttpClient httpclient = new HttpClient())
//            {
//                HttpResponseMessage responseApi = await httpclient.GetAsync("https://localhost:7284/api/brand");
//                string contentResponseApi = await responseApi.Content.ReadAsStringAsync();
//                response = JsonSerializer.Deserialize<Response<List<BrandSlimViewModel>>>(contentResponseApi);
//            }

//            return response.Data;
//        }

//        private async Task<List<SubCategorySlimViewModel>> GetSubCategoriesAsync()
//        {
//            Response<List<SubCategorySlimViewModel>> response = new Response<List<SubCategorySlimViewModel>>();
//            using (HttpClient httpclient = new HttpClient())
//            {
//                HttpResponseMessage responseApi = await httpclient.GetAsync("https://localhost:7284/api/subcategory");
//                string contentResponseApi = await responseApi.Content.ReadAsStringAsync();
//                response = JsonSerializer.Deserialize<Response<List<SubCategorySlimViewModel>>>(contentResponseApi);
//            }

//            return response.Data;
//        }

//        [HttpGet]
//        public async Task<IActionResult> Edit(int id)
//        {

//            ProductViewModel product = await GetProductAsync(id);
           
//            var brands = await GetBrandsAsync();
//            var brandListItem= brands.Select(x => new SelectListItem
//            {
//                Value = x.Id.ToString(),
//                Text = x.Name,
//            }).ToList();


//            var subCategories = await GetSubCategoriesAsync();
//            var subCategoryListItem = subCategories.Select(x => new SelectListItem
//            {
//                Value = x.Id.ToString(),
//                Text = x.Name,
//            }).ToList();

//            var model = new EditProductViewModel()
//            {
//                Id = product.Id,
//                BrandList = brandListItem,
//                SubCategoryList = subCategoryListItem,
//                Price = product.Price,
//                Description = product.Description,
//                ImageUrl = product.ImageUrl,
//                IsActive = product.IsActive,
//                IsHome = product.IsHome,
//                Name = product.Name,
//                Url = product.Url,
//                Properties = product.Properties,
//                BrandId = product.Brand.Id,
//                SubCategoryId = product.SubCategory.Id,
//            };

//           return View(model);

//        }

//        [HttpPost]
//        public async Task<IActionResult> Edit(EditProductViewModel editProductViewModel)
//        {

//            return View();

//        }
//    }
//}
