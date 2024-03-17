using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Shared.ViewModels.Identity
{
    public class RegisterViewModel
    {
        [DisplayName("Ad")]
        [Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        public string LastName  { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen geçerli bir email adresi giriniz.")]
        public string Email  { get; set; }

        [DisplayName("Şifre")]
        [Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Şifre")]
        [Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parolalar eşleşmiyor, lütfen kontrol ediniz.")]
        public string RePassword { get; set; }

        //public string ConfirmDesc { get; set; }
    }
}
