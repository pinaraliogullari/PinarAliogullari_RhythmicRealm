using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Entity.Concrete.Identity;
using RhythmicRealm.Service.Abstract;

namespace RhythmicRealm.UI.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly UserManager<User> _userManager;

		public HomeController(IOrderService orderService, IProductService productService, UserManager<User> userManager)
		{
			_orderService = orderService;
			_productService = productService;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetOrdersAsync();
            return View(orders.Data);
        }

        public async Task<IActionResult> GetNewProducts()
        {
            var newProducts = await _productService.GetNewProductsAsync();
            return View(newProducts.Data);
        }
        public async Task<IActionResult> GetNewUsers()
        {
			var currentTime = DateTime.Now;
			var newUsers = _userManager.Users.Where(u => u.CreatedDate >= currentTime.AddDays(-1)).ToList();
            return View(newUsers);

		}
	}
}
