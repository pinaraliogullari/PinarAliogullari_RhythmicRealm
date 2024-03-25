using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Service.Abstract;

namespace RhythmicRealm.UI.ViewComponents
{
	public class SearchBarViewComponent:ViewComponent
	{
		
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}

	
	}
}
