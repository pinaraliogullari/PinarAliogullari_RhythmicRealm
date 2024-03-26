using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.MessageViewModel;


namespace RhythmicRealm.Service.Abstract
{
	public interface IContactService
	{
		Task<Response<List<ContactViewModel>>> GetMessagesListAsync();
		Task<Response<ContactViewModel>> GetMessageAsync(int id);
		Task<Response<NoContent>> CreateMessageAsync(ContactViewModel contactViewModel);
		Task<Response<NoContent>> UpdateMessageAsync(ContactViewModel contactViewModel);
		Task<Response<NoContent>> DeleteMessageAsync(ContactViewModel contactViewModel);


	}
}
