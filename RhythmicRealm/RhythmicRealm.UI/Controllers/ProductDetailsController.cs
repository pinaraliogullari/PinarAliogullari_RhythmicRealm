using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Service.Abstract;

namespace RhythmicRealm.UI.Controllers
{
    public class ProductDetailsController : Controller
    {
        private readonly IProductService _productService;

		public ProductDetailsController(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<IActionResult> Index(int id)
        {
            var product= await _productService.GetProductByProductIdAsync(id);
            var model = product.Data;
            return View(model);
        }
    }
}
