using Microsoft.AspNetCore.Mvc;

namespace RhythmicRealm.UI.ViewComponents
{
	public class WishlistViewComponent:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
