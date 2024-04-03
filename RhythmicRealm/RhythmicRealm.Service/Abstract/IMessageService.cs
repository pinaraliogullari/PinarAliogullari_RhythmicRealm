using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.MessageViewModels;


namespace RhythmicRealm.Service.Abstract
{
	public interface IMessageService
    {
        Task<Response<List<AdminMessageViewModel>>> GetMessagesListInInboxAsync();
        Task<Response<List<AdminMessageViewModel>>> GetMessagesListInSendboxAsync();
        Task<Response<AdminMessageViewModel>> GetMessageAsync(int id);
        Task<Response<List<AdminMessageViewModel>>> GetTrashMessagesAsync();
        Task<Response<NoContent>> CreateMessageAsync(AdminMessageViewModel messageViewModel);
        Task<Response<NoContent>> SoftDeleteMessageAsync(int id);
        Task<Response<NoContent>> HardDeleteMessageAsync(int id);
        Task<Response<NoContent>> UpdateMessageAsync(int id);
        Task<Response<int>> GetMessageCountAsync(bool isRead=false);
    }
}
