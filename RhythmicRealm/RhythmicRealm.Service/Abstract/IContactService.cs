using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.MessageViewModels;



namespace RhythmicRealm.Service.Abstract
{
	public interface IContactService
	{
		Task<Response<List<UserMessageViewModel>>> GetMessagesListInInboxAsync();
        Task<Response<UserMessageViewModel>> GetMessageAsync(int id);
		Task<Response<NoContent>> CreateMessageAsync(UserMessageViewModel contactViewModel);
		Task<Response<NoContent>> UpdateMessageAsync(int id);
		Task<Response<NoContent>> HardDeleteMessageAsync(int id);
		Task<Response<NoContent>> SoftDeleteMessageAsync(int id);
		Task<Response<int>> GetMessageCountAsync(string userId, bool isRead = false);
        Task<Response<List<UserMessageViewModel>>> GetTrashMessagesAsync();



    }
}
