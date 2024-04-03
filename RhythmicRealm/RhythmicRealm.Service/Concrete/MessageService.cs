using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Entity.Concrete.Identity;
using RhythmicRealm.Entity.Concrete.Others;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.MessageViewModels;


namespace RhythmicRealm.Service.Concrete
{
	public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly UserManager<User> _userManager;
		private readonly IHttpContextAccessor _httpContextAccessor;
		public MessageService(IMessageRepository messageRepository, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
		{
			_messageRepository = messageRepository;
			_userManager = userManager;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<Response<NoContent>> CreateMessageAsync(AdminMessageViewModel messageViewModel)
        {
            var message = messageViewModel.Adapt<Message>();
            if (message == null)
                return Response<NoContent>.Fail(500, "Bir hata meydana geldi.");
            await _messageRepository.CreateAsync(message);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<NoContent>> SoftDeleteMessageAsync(int id)
        {

            var message = await _messageRepository.GetAsync(x => x.Id == id);
            message.IsDeleted = true;
            await _messageRepository.UpdateAsync(message);
            return Response<NoContent>.Success(200);
        }
        public async Task<Response<NoContent>> HardDeleteMessageAsync(int id)
        {
            var message = await _messageRepository.GetAsync(x => x.Id == id);
            await _messageRepository.HardDeleteAsync(message);
            return Response<NoContent>.Success(200);
        }
        public async Task<Response<AdminMessageViewModel>> GetMessageAsync(int id)
        {
            var message = await _messageRepository.GetAsync(x => x.Id == id);
            if (message == null)
                return Response<AdminMessageViewModel>.Fail(404, "Mesaj bulunamadı");
            var messageViewModel = message.Adapt<AdminMessageViewModel>();
            return Response<AdminMessageViewModel>.Success(messageViewModel, 200);
        }

        public async Task<Response<int>> GetMessageCountAsync(bool isRead=false)
        {
            var userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            var user = await _userManager.FindByIdAsync(userId);
            var count = await _messageRepository.GetCount(m=>m.IsRead == isRead&& m.ReceiverMail==user.Email);
            return Response<int>.Success(count,200);
        }

        public async Task<Response<List<AdminMessageViewModel>>> GetMessagesListInInboxAsync()
        {
		 
			var userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            var user= await _userManager.FindByIdAsync(userId);
            var messages = await _messageRepository.GetAllAsync(x=>x.ReceiverMail==user.Email && x.IsDeleted==false);
            if (messages == null)
                return Response<List<AdminMessageViewModel>>.Fail(404, "Mesaj bulunamadı");
            var messageViewModel = messages.Adapt<List<AdminMessageViewModel>>();
            return Response<List<AdminMessageViewModel>>.Success(messageViewModel, 200);
        }

        public async Task<Response<List<AdminMessageViewModel>>> GetMessagesListInSendboxAsync()
        {
			var userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
			var user = await _userManager.FindByIdAsync(userId);
			var messages = await _messageRepository.GetAllAsync(x => x.SenderMail == user.Email);
            if (messages == null)
                return Response<List<AdminMessageViewModel>>.Fail(404, "Mesaj bulunamadı");
            var messageViewModel = messages.Adapt<List<AdminMessageViewModel>>();
            return Response<List<AdminMessageViewModel>>.Success(messageViewModel, 200);
        }

        public async Task<Response<List<AdminMessageViewModel>>> GetTrashMessagesAsync()
        {
            var messages = await _messageRepository.GetAllAsync(x => x.IsDeleted);
            if (messages == null)
                return Response<List<AdminMessageViewModel>>.Fail(500, "Bir hata meydana geldi.");
            var messageViewModel = messages.Adapt<List<AdminMessageViewModel>>();
            return Response<List<AdminMessageViewModel>>.Success(messageViewModel, 200);

        }

        public async Task<Response<NoContent>> UpdateMessageAsync(int id)
        {
            var message = await _messageRepository.GetAsync(x => x.Id == id);
            message.IsRead = true;
            await _messageRepository.UpdateAsync(message);
            return Response<NoContent>.Success(200);
        }

      
    }
}
