using Microsoft.AspNetCore.Mvc;

namespace RhythmicRealm.UI.Areas.Admin.ViewComponents
{
    public class NavbarMessagesViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
