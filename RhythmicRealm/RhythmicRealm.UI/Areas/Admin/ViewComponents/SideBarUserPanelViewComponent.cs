using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Entity.Concrete.Identity;

namespace RhythmicRealm.UI.Areas.Admin.ViewComponents
{
    public class SideBarUserPanelViewComponent:ViewComponent
    {
        private readonly UserManager<User> _userManager;

        public SideBarUserPanelViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var user = await _userManager.FindByIdAsync(userId);
            var fullName=$"{user.FirstName} {user.LastName}";
            return View("default", fullName);
        }
    }
}
