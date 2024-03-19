using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Shared.ViewModels.Identity
{
    public class ResetPasswordViewModel
    {
		public string UserId { get; set; }
		public string TokenCode { get; set; }

        [DisplayName("Yeni Parola")]
		[Required(ErrorMessage = "{0} alanını boş bırakmayınız")]
		[DataType(DataType.Password,ErrorMessage ="Lütfen uygun formatta parola oluşturunuz.")]
		public string Password { get; set; }

		[DisplayName("Yeni Parola Tekrar")]
		[Required(ErrorMessage = "{0} alanını boş bırakmayınız.")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "İki parola birbiriyle uyuşmuyor.")]
		public string RePassword { get; set; }
	}
}
