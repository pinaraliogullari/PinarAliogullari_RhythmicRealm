namespace RhythmicRealm.Shared.ViewModels.MessageViewModels
{
	public class AllMessagesViewModel
    {
        public List<UserMessageViewModel> UserMessages { get; set; }
        public List<AdminMessageViewModel> AdminMessages { get; set; }
    }
}
