using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.MessageViewModels;



namespace RhythmicRealm.Service.Abstract
{
    public interface IContactService
	{
		Task<Response<List<UserMessageViewModel>>> GetMessagesListInInboxAsync();
        Task<Response<UserMessageViewModel>> GetMessageAsync(int id);
		Task<Response<NoContent>> CreateMessageAsync(UserMessageViewModel contactViewModel);
		Task<Response<NoContent>> UpdateMessageAsync(UserMessageViewModel contactViewModel);
		Task<Response<NoContent>> DeleteMessageAsync(UserMessageViewModel contactViewModel);


	}
}
