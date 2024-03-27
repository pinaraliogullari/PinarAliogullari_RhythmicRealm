using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.MessageViewModel;
using RhythmicRealm.Shared.ViewModels.MessageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Service.Abstract
{
    public interface IMessageService
    {
        Task<Response<List<MessageViewModel>>> GetMessagesListInInboxAsync();
        Task<Response<List<MessageViewModel>>> GetMessagesListInSendboxAsync();
        Task<Response<MessageViewModel>> GetMessageAsync(int id);
        Task<Response<NoContent>> CreateMessageAsync(MessageViewModel messageViewModel);
        Task<Response<NoContent>> UpdateMessageAsync(MessageViewModel messageViewModel);
        Task<Response<NoContent>> DeleteMessageAsync(MessageViewModel messageViewModel);
    }
}
