using Microsoft.AspNetCore.Mvc;

namespace RhythmicRealm.UI.Controllers
{
	public class AboutUsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
