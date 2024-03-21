using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Shared.ViewModels.Identity
{
    public class LoginViewModel
    {
        [DisplayName("E-posta")]
        [Required(ErrorMessage ="Lütfen mail adresinizi giriniz.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen geçerli bir mail adresi giriniz.")]
        public string Email { get; set; }

        [DisplayName("Şifre")]
        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        [DataType(DataType.Password, ErrorMessage = "Şifreniz en az 7 karakter ve en fazla 20 karakter olmalı, harf ve rakam içermelidir.")]
        public string Password { get; set; }
        public virtual bool RememberMe{ get; set; }
    }
}
