﻿using Microsoft.AspNetCore.Mvc;

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
