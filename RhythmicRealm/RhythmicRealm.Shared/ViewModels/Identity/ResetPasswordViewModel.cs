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

		[DisplayName("Parola")]
		[Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[DisplayName("Parola Tekrar")]
		[Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "İki şifre birbiriyle uyuşmuyor.")]
		public string RePassword { get; set; }
	}
}
