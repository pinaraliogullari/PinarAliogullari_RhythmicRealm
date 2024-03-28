using AspNetCoreHero.ToastNotification.Abstractions;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Entity.Concrete.Identity;
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
        private readonly UserManager<User> _userManager;

		public MessageController(IMessageService messageService, IContactService contactService, INotyfService notyfService, UserManager<User> userManager)
		{
			_messageService = messageService;
			_contactService = contactService;
			_notyfService = notyfService;
			_userManager = userManager;
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
            //if (model.UserMessages == null && model.AdminMessages == null)
            //{
            //    ViewBag.InboxMessage = "Görüntülenecek mesaj bulunmamaktadır.";
            //}

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
            var result = await _contactService.GetMessageAsync(id);
            var message = result.Data;
            await _contactService.UpdateMessageAsync(id);
            return View(message);
        }

        public async Task<IActionResult> GetAdminMessageDetails(int id)
        {
            var result = await _messageService.GetMessageAsync(id);
            var message = result.Data;
            await _messageService.UpdateMessageAsync(id);
            return View(message);
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
            var userId = _userManager.GetUserId(User);
            var user= await _userManager.FindByIdAsync(userId);
            message.SenderMail = user.Email;
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

        public async Task<IActionResult> SoftDeleteMessage(int id)
        {
       
            var result= await _messageService.SoftDeleteMessageAsync(id);
            if (result.IsSucceesed)
            {
                _notyfService.Success("Mesaj çöp kutusuna gönderilmiştir.");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> HardDeleteMessage(int id)
        {

            var result = await _messageService.HardDeleteMessageAsync(id);
            if (result.IsSucceesed)
            {
                _notyfService.Success("Mesaj kalıcı olarak silinmiştir.");
                return RedirectToAction("TrashMessages");
            }
            _notyfService.Error("Mesaj silinirken bir hata oluştu.");
            return RedirectToAction("TrashMessages");

        }
        public async Task<IActionResult> TrashMessages()
        {
            var trashMessages = await _messageService.GetTrashMessagesAsync();
            if (trashMessages.Data.Any())
                return View(trashMessages.Data);
            else
            {
                ViewBag.TrashBoxMessage = "Silinecek mesaj bulunmamaktadır.";
                return View();
            }
        }

    }
}
