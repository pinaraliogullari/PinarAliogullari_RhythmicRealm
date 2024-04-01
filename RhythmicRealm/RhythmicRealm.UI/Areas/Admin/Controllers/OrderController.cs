using Microsoft.AspNetCore.Mvc;

namespace RhythmicRealm.UI.Areas.Admin.Controllers
{
	public class OrderController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
