﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RhythmicRealm.Shared.ViewModels.Identity
{
	public class UserViewModel
    {
        public string UserId { get; set; }

        [DisplayName("Ad")]
        [Required(ErrorMessage = "{0} alanını boş bırakmayınız")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "{0} alanını boş bırakmayınız")]
        public string LastName { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "{0} alanını boş bırakmayınız")]
        public string Email { get; set; }

        [DisplayName("Cep Telefonu")]
        [Required(ErrorMessage = "{0} alanını boş bırakmayınız")]
        public string PhoneNumber { get; set; }


        [DisplayName("Doğum Tarihi")]
        [Required(ErrorMessage = "{0} alanını boş bırakmayınız")]
        public DateTime? DateofBirth { get; set; }

		[DisplayName("Adres")]
		[Required(ErrorMessage = "{0} alanını boş bırakmayınız")]
		public string Address { get; set; }

		[DisplayName("Şehir")]
		[Required(ErrorMessage = "{0} alanını boş bırakmayınız")]
		public string City { get; set; }
      
    }
}
