using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Shared.ViewModels.Identity
{
    public class UpdatePasswordViewModel
    {
        [DisplayName("Şu Anki Şifre")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [DisplayName("Yeni Şifre")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DisplayName("Yeni şifre(Tekrar)")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
        [DataType(DataType.Password, ErrorMessage = "Şifreniz en az 7 karakter ve en fazla 20 karakter olmalı, harf ve rakam içermelidir.")]
        [Compare("NewPassword", ErrorMessage = "Şifreler uyuşmuyor!")]
        public string ReNewPassword { get; set; }
    }
}
