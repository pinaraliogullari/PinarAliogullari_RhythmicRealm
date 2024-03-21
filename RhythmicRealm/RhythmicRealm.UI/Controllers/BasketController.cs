using Microsoft.AspNetCore.Mvc;

namespace RhythmicRealm.UI.Controllers
{
	public class BasketController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
