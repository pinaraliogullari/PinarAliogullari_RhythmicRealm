using Microsoft.AspNetCore.Mvc;

namespace RhythmicRealm.UI.Areas.Admin.ViewComponents
{
    public class SideBarUserPanelViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
