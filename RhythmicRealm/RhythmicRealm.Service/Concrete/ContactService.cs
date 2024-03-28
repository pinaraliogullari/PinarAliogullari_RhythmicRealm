using Mapster;
using MapsterMapper;
using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Data.Concrete.Repositories;
using RhythmicRealm.Entity.Concrete;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.MessageViewModels;



namespace RhythmicRealm.Service.Concrete
{
    public class ContactService : IContactService
	{
		private readonly IContactRepository _contactRepository;
		public ContactService(IContactRepository messageRepository)
		{
			_contactRepository = messageRepository;
		}

		public async Task<Response<NoContent>> CreateMessageAsync(UserMessageViewModel contactViewModel)
		{
			var message = contactViewModel.Adapt<Contact>();
			var createdMessage = await _contactRepository.CreateAsync(message);
			if (createdMessage == null)
			{
				return Response<NoContent>.Fail(500,"Mesaj gönderilemedi");
			}
	
			return Response<NoContent>.Success(200);
		}

        public async Task<Response<NoContent>> SoftDeleteMessageAsync(int id)
        {

            var message = await _contactRepository.GetAsync(x => x.Id == id);
            message.IsDeleted = true;
            await _contactRepository.UpdateAsync(message);
            return Response<NoContent>.Success(200);
        }
        public async Task<Response<NoContent>> HardDeleteMessageAsync(int id)
		{
            var message = await _contactRepository.GetAsync(x => x.Id == id);
			await _contactRepository.HardDeleteAsync(message);
			return Response<NoContent>.Success(200);
		}

		public async Task<Response<UserMessageViewModel>> GetMessageAsync(int id)
		{
			var message= await _contactRepository.GetAsync(x=> x.Id == id);
			if (message == null)
				return Response<UserMessageViewModel>.Fail(404, "Mesaj bulunamadı");
			var messageViewModel=message.Adapt<UserMessageViewModel>();
			return Response<UserMessageViewModel>.Success(messageViewModel, 200);
		}

		public Task<Response<int>> GetMessageCountAsync(string userId, bool isRead = false)
		{
			throw new NotImplementedException();
		}

		public async Task<Response<List<UserMessageViewModel>>> GetMessagesListInInboxAsync()
		{
			var messages = await _contactRepository.GetAllAsync(x=>x.IsDeleted==false);
			if (messages == null)
				return Response<List<UserMessageViewModel>>.Fail(404, "Mesaj bulunamadı");
			var messageViewModel = messages.Adapt<List<UserMessageViewModel>>();
			return Response<List<UserMessageViewModel>>.Success(messageViewModel, 200);
		}

        public async Task<Response<NoContent>> UpdateMessageAsync(int id)
		{
            var message = await _contactRepository.GetAsync(x => x.Id == id);
            message.IsRead = true;
            await _contactRepository.UpdateAsync(message);
            return Response<NoContent>.Success(200);

        }

        public async Task<Response<List<UserMessageViewModel>>> GetTrashMessagesAsync()
        {
            var messages = await _contactRepository.GetAllAsync(x => x.IsDeleted);
            if (messages == null)
                return Response<List<UserMessageViewModel>>.Fail(500, "Bir hata meydana geldi.");
            var messageViewModel = messages.Adapt<List<UserMessageViewModel>>();
            return Response<List<UserMessageViewModel>>.Success(messageViewModel, 200);
        }
    }
}
