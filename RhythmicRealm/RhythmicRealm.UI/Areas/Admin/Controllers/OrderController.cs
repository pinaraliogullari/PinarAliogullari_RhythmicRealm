using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.ComplexTypes;
using RhythmicRealm.Shared.Extensions;
using RhythmicRealm.UI.Areas.Admin.AdminViewModels;

namespace RhythmicRealm.UI.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class OrderController : Controller
	{
        private readonly IProductService _productService;
		private readonly IOrderService _orderService;
	

        public OrderController(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
        }

        public async Task<IActionResult> Index(bool isdeleted)
		{
			var orders = await _orderService.GetOrdersAsync();
            var products = await _productService.GetProductsByIsDeleteAsync(isdeleted);
            List<SelectListItem> productListItems = products.Data.Select(x => new SelectListItem
			{
				Text = x.Name,
				Value = x.Id.ToString()
			}).ToList();

			var orderFilterViewModel = new OrderFilterViewModel
			{
				Products = productListItems,
				Orders = orders.Data,

			};
			return View(orderFilterViewModel);
        }

		public async Task<IActionResult> FilterByProduct(int id)
		{
			if (id == 0)
			{
				var orders= await _orderService.GetOrdersAsync();
                return PartialView("_FilteredOrderPartialView", orders.Data);
			}
			else
			{
                var orders = await _orderService.GetOrdersAsync(id);
                return PartialView("_FilteredOrderPartialView", orders.Data);
            }
		}

		public async Task<IActionResult> UpdateOrderState(int id)
		{
            var orderState = await _orderService.UpdateOrderStateAsync(id, EnumOrderState.Preparing);
			var orderStateDisplay= orderState.GetDisplayName();
			return Json(orderStateDisplay);
		}
	}
}
