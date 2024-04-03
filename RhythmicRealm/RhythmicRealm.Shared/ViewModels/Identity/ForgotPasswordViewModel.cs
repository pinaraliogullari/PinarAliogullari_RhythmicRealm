using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RhythmicRealm.Shared.ViewModels.Identity
{
	public class ForgotPasswordViewModel
    {
        [DisplayName("Eposta")]
        [Required(ErrorMessage ="Lütfen epostanızı giriniz.")]
        public string Email { get; set; }
    }
}
