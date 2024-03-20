using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Shared.ViewModels.Identity
{
    public class ProfileViewModel
    {
        public UserViewModel UserInfo { get; set; }
        public UpdatePasswordViewModel? PasswordInfo { get; set; }
    }
}
