using Mapster;
using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Data.Concrete.Repositories;
using RhythmicRealm.Entity.Concrete.Others;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.MessageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Service.Concrete
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<Response<NoContent>> CreateMessageAsync(AdminMessageViewModel messageViewModel)
        {
            var message = messageViewModel.Adapt<Message>();
            if (message == null)
                return Response<NoContent>.Fail(404, "Bir hata meydana geldi.");
            await _messageRepository.CreateAsync(message);
            return Response<NoContent>.Success(200);
        }

        public Task<Response<NoContent>> DeleteMessageAsync(AdminMessageViewModel messageViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<AdminMessageViewModel>> GetMessageAsync(int id)
        {
            var message = await _messageRepository.GetAsync(x => x.Id == id);
            if (message == null)
                return Response<AdminMessageViewModel>.Fail(404, "Mesaj bulunamadı");
            var messageViewModel = message.Adapt<AdminMessageViewModel>();
            return Response<AdminMessageViewModel>.Success(messageViewModel, 200);
        }

        public async Task<Response<List<AdminMessageViewModel>>> GetMessagesListInInboxAsync()
        {
            var messages = await _messageRepository.GetAllAsync(x=>x.ReceiverMail=="admin@gmail.com");
            if (messages == null)
                return Response<List<AdminMessageViewModel>>.Fail(404, "Mesaj bulunamadı");
            var messageViewModel = messages.Adapt<List<AdminMessageViewModel>>();
            return Response<List<AdminMessageViewModel>>.Success(messageViewModel, 200);
        }

        public async Task<Response<List<AdminMessageViewModel>>> GetMessagesListInSendboxAsync()
        {
            var messages = await _messageRepository.GetAllAsync(x => x.SenderMail == "admin@gmail.com");
            if (messages == null)
                return Response<List<AdminMessageViewModel>>.Fail(404, "Mesaj bulunamadı");
            var messageViewModel = messages.Adapt<List<AdminMessageViewModel>>();
            return Response<List<AdminMessageViewModel>>.Success(messageViewModel, 200);
        }

       
    }
}
