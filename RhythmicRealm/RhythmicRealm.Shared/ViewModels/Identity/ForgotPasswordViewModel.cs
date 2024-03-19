using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Shared.ViewModels.Identity
{
    public class ForgotPasswordViewModel
    {
        [DisplayName("Eposta")]
        [Required(ErrorMessage ="Lütfen epostanızı giriniz.")]
        public string Email { get; set; }
    }
}
