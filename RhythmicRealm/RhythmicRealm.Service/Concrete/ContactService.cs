using Mapster;
using MapsterMapper;
using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Entity.Concrete;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.MessageViewModel;
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

		public async Task<Response<NoContent>> CreateMessageAsync(ContactViewModel contactViewModel)
		{
			var message = contactViewModel.Adapt<Contact>();
			var createdMessage = await _contactRepository.CreateAsync(message);
			if (createdMessage == null)
			{
				return Response<NoContent>.Fail(500,"Mesaj gönderilemedi");
			}
	
			return Response<NoContent>.Success(200);
		}

		public async Task<Response<NoContent>> DeleteMessageAsync(ContactViewModel contactViewModel)
		{
			var deletedMessage= contactViewModel.Adapt<Contact>();
			await _contactRepository.HardDeleteAsync(deletedMessage);
			return Response<NoContent>.Success(200);
		}

		public async Task<Response<ContactViewModel>> GetMessageAsync(int id)
		{
			var message= await _contactRepository.GetAsync(x=> x.Id == id);
			if (message == null)
				return Response<ContactViewModel>.Fail(404, "Mesaj bulunamadı");
			var messageViewModel=message.Adapt<ContactViewModel>();
			return Response<ContactViewModel>.Success(messageViewModel, 200);
		}

		public async Task<Response<List<ContactViewModel>>> GetMessagesListAsync()
		{
			var messages = await _contactRepository.GetAllAsync();
			if (messages == null)
				return Response<List<ContactViewModel>>.Fail(404, "Mesaj bulunamadı");
			var messageViewModel = messages.Adapt<List<ContactViewModel>>();
			return Response<List<ContactViewModel>>.Success(messageViewModel, 200);
		}

		public async Task<Response<NoContent>> UpdateMessageAsync(ContactViewModel contactViewModel)
		{
			var message= contactViewModel.Adapt<Contact>();
			if (message == null)
				return Response<NoContent>.Fail(404,"Mesaj bulunamadı.");
			await _contactRepository.UpdateAsync(message);
			return Response<NoContent>.Success(200);

		}
	}
}
