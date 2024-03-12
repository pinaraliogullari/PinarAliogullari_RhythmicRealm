using Microsoft.AspNetCore.Mvc;

namespace RhythmicRealm.UI.ViewComponents
{
	public class CartViewComponent:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
