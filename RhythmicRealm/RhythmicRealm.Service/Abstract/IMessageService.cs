using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.MessageViewModels;


namespace RhythmicRealm.Service.Abstract
{
    public interface IMessageService
    {
        Task<Response<List<AdminMessageViewModel>>> GetMessagesListInInboxAsync();
        Task<Response<List<AdminMessageViewModel>>> GetMessagesListInSendboxAsync();
        Task<Response<AdminMessageViewModel>> GetMessageAsync(int id);
        Task<Response<NoContent>> CreateMessageAsync(AdminMessageViewModel messageViewModel);
        Task<Response<NoContent>> DeleteMessageAsync(AdminMessageViewModel messageViewModel);
    }
}
