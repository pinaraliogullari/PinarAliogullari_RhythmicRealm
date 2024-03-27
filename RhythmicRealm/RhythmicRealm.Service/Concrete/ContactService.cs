using Mapster;
using MapsterMapper;
using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Data.Concrete.Repositories;
using RhythmicRealm.Entity.Concrete;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.MessageViewModels;
using System;
using System.Runtime.CompilerServices;


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

		public async Task<Response<NoContent>> DeleteMessageAsync(UserMessageViewModel contactViewModel)
		{
			var deletedMessage= contactViewModel.Adapt<Contact>();
			await _contactRepository.HardDeleteAsync(deletedMessage);
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

		public async Task<Response<List<UserMessageViewModel>>> GetMessagesListInInboxAsync()
		{
			var messages = await _contactRepository.GetAllAsync();
			if (messages == null)
				return Response<List<UserMessageViewModel>>.Fail(404, "Mesaj bulunamadı");
			var messageViewModel = messages.Adapt<List<UserMessageViewModel>>();
			return Response<List<UserMessageViewModel>>.Success(messageViewModel, 200);
		}

        public async Task<Response<NoContent>> UpdateMessageAsync(UserMessageViewModel contactViewModel)
		{
			var message= contactViewModel.Adapt<Contact>();
			if (message == null)
				return Response<NoContent>.Fail(404,"Mesaj bulunamadı.");
			await _contactRepository.UpdateAsync(message);
			return Response<NoContent>.Success(200);

		}
	}
}
