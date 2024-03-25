using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Service.Abstract;
using System.Diagnostics;

namespace RhythmicRealm.UI.Controllers
{
	public class HomeController : Controller
	{

		private readonly IProductService _productService;
		public HomeController(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<IActionResult> Index()
		{
			var products = await _productService.GetAllProductsAsync();
			var model = products.Data;

			return View(model);
		}

	

	}
}
