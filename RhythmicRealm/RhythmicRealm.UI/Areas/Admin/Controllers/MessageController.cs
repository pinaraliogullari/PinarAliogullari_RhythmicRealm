using AspNetCoreHero.ToastNotification.Abstractions;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop.Infrastructure;
using RhythmicRealm.Entity.Concrete.Others;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.ViewModels.MessageViewModels;

namespace RhythmicRealm.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IContactService _contactService;
        private readonly INotyfService _notyfService;

        public MessageController(IMessageService messageService, IContactService contactService, INotyfService notyfService)
        {
            _messageService = messageService;
            _contactService = contactService;
            _notyfService = notyfService;
        }

        public async Task<IActionResult> Index(string messageType = "All")
        {

            List<UserMessageViewModel> userMessages = null;
            List<AdminMessageViewModel> adminMessages = null;

            if (messageType == "User" || messageType == "All")
            {
                userMessages = await GetUserMessagesListInInbox();
            }

            if (messageType == "Admin" || messageType == "All")
            {
                adminMessages = await GetAdminMessagesListInInbox();
            }

            var model = new AllMessagesViewModel
            {
                AdminMessages = adminMessages,
                UserMessages = userMessages
            };

            return View(model);
        }

        private async Task<List<AdminMessageViewModel>> GetAdminMessagesListInInbox()
        {
            var adminMessages = await _messageService.GetMessagesListInInboxAsync();
            return adminMessages.Data;
        }
        private async Task<List<UserMessageViewModel>> GetUserMessagesListInInbox()
        {
            var userMessages = await _contactService.GetMessagesListInInboxAsync();
            return userMessages.Data;
        }
    
        public async Task<IActionResult> GetUserMessageDetails(int id)
        {
            var message = await _contactService.GetMessageAsync(id);
            return View(message.Data);
        }

        public async Task<IActionResult> GetAdminMessageDetails(int id)
        {
            var message = await _messageService.GetMessageAsync(id);
            return View(message.Data);
        }

        public async Task<IActionResult> SendBox()
        {
            var messageList = await _messageService.GetMessagesListInSendboxAsync();
            return View(messageList.Data);
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
        public async Task<IActionResult> NewMessage(AdminMessageViewModel message)
        {

            message.SenderMail = "admin@gmail.com"; //burayı düzelticem.
            message.MessageDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                await _messageService.CreateMessageAsync(message);
                _notyfService.Success("Mesajınız başarıyla gönderildi.");
                return RedirectToAction("SendBox");
            }
            _notyfService.Error("Mesaj gönderilemedi.");
            return View(message);

        }
    }
}
