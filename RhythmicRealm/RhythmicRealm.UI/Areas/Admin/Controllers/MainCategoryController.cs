using Microsoft.AspNetCore.Mvc;

namespace RhythmicRealm.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MainCategoryController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
