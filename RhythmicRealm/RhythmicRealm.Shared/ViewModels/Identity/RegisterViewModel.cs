using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RhythmicRealm.Shared.ViewModels.Identity
{
	public class RegisterViewModel
    {
        [DisplayName("Adınız")]
        [Required(ErrorMessage = "-Lütfen {0} alanını boş bırakmayınız.")]
        public string FirstName { get; set; }

        [DisplayName("Soyadınız")]
        [Required(ErrorMessage = "-Lütfen {0} alanını boş bırakmayınız.")]
        public string LastName  { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "-Lütfen email alanını boş bırakmayınız.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen geçerli bir email adresi giriniz.")]
        public string Email  { get; set; }

        [DisplayName("Şifre")]
        [Required(ErrorMessage = "-Lütfen {0} alanını boş bırakmayınız.")]
        [DataType(DataType.Password,ErrorMessage ="Şifreniz en az 7 karakter ve en fazla 20 karakter olmalı, harf ve rakam içermelidir.")]
        public string Password { get; set; }

        [DisplayName("Şifre Tekrar")]
        [Required(ErrorMessage = "-Lütfen {0} alanını boş bırakmayınız.")]
        [DataType(DataType.Password, ErrorMessage = "Şifreniz en az 7 karakter ve en fazla 20 karakter olmalı, harf ve rakam içermelidir.")]
        [Compare("Password",ErrorMessage ="Şifreler birbiriyle uyumlu olmalıdır.")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Üye olmak için şartları kabul etmeniz gerekmektedir.")]
        public bool MemberShipTerms { get; set; }
    }
}
