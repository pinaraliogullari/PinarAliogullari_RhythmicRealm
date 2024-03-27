using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Service.Concrete;
using RhythmicRealm.Shared.ViewModels.MessageViewModels;

namespace RhythmicRealm.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<IActionResult> Inbox()
        {
            var messageList = await _messageService.GetMessagesListInInboxAsync();
            return View(messageList.Data);
        }

        public async Task<IActionResult> SendBox()
        {
            var messageList = await _messageService.GetMessagesListInSendboxAsync();
            return View(messageList.Data);
        }
        public async Task<IActionResult> GetInBoxMessageDetails(int id)
        {
            var message = await _messageService.GetMessageAsync(id);
            return View(message.Data);
        }
        public async Task<IActionResult> GetSendBoxMessageDetails(int id)
        {
            var message = await _messageService.GetMessageAsync(id);
            return View(message.Data);
        }
        public async Task<IActionResult> NewMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewMessage(MessageViewModel message)
        {
            var messageList = await _messageService.GetMessagesListInSendboxAsync();
            return View(messageList.Data);
        }
    }
}
