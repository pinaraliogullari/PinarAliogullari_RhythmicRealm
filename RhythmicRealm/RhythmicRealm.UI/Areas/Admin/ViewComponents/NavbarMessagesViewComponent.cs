using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Service.Abstract;

namespace RhythmicRealm.UI.Areas.Admin.ViewComponents
{
    public class NavbarMessagesViewComponent:ViewComponent
    {
        private readonly IMessageService _messageService;

        public NavbarMessagesViewComponent(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var messageCount = await _messageService.GetMessageCountAsync();
            var model = messageCount.Data;
            return View(model);
        }
    }
}
