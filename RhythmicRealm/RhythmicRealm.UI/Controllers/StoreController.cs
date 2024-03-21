using Microsoft.AspNetCore.Mvc;

namespace RhythmicRealm.UI.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
