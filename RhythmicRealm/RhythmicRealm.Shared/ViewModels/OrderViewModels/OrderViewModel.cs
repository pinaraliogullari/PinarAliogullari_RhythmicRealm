using RhythmicRealm.Shared.ViewModels.ShoppingBasketViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RhythmicRealm.Shared.ViewModels.OrderViewModels
{
	public class OrderViewModel
	{
		[Required(ErrorMessage ="Lütfen {0} alanını boş bırakmayınız")]
		[DisplayName("Ad")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız")]
		[DisplayName("Soyad")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız")]
		[DisplayName("Adres")]
		public string Address { get; set; }

		[Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız")]
		[DisplayName("Şehir")]
		public string City { get; set; }

		[Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız")]
		[DisplayName("Telefon numarası")]
		public string PhoneNumber { get; set; }

		[Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız")]
		[DisplayName("Email")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız")]
		[DisplayName("Kart Üzerindeki Ad Soyad")]
		public string CardName { get; set; }

		[Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız")]
		[DisplayName("Kart Numarası")]
		public string CardNumber { get; set; }

		[Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız")]
		[DisplayName("Geçerlilik Ay")]
		public string ExpirationMonth { get; set; }

		[Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız")]
		[DisplayName("Geçerlilik Yıl")]
		public string ExpirationYear { get; set; }

		[Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız")]
		[DisplayName("Cvc")]
		public string Cvc { get; set; }
		public ShoppingBasketViewModel ShoppingBasket { get; set; }
	}
}
