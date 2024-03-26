using Mapster;
using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Data.Concrete.Repositories;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.MessageViewModel;
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

        public Task<Response<NoContent>> CreateMessageAsync(MessageViewModel messageViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContent>> DeleteMessageAsync(MessageViewModel messageViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<Response<MessageViewModel>> GetMessageAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<MessageViewModel>>> GetMessagesListAsync()
        {
            var messages = await _messageRepository.GetAllAsync(x=>x.ReceiverMail=="admin@gmail.com");
            if (messages == null)
                return Response<List<MessageViewModel>>.Fail(404, "Mesaj bulunamadı");
            var messageViewModel = messages.Adapt<List<MessageViewModel>>();
            return Response<List<MessageViewModel>>.Success(messageViewModel, 200);
        }

        public Task<Response<NoContent>> UpdateMessageAsync(MessageViewModel messageViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
