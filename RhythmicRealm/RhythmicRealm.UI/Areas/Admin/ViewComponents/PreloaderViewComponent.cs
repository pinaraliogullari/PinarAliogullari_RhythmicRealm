using Microsoft.AspNetCore.Mvc;

namespace RhythmicRealm.UI.Areas.Admin.ViewComponents
{
    public class PreloaderViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
