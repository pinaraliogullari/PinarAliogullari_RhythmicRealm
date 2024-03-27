using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Shared.ViewModels.MessageViewModels
{
    public class AllMessagesViewModel
    {
        public List<UserMessageViewModel> UserMessages { get; set; }
        public List<AdminMessageViewModel> AdminMessages { get; set; }
    }
}
