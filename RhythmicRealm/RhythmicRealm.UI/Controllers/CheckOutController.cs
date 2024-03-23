using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RhythmicRealm.UI.Controllers
{
	[Authorize]
	public class CheckOutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
