using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RhythmicRealm.Shared.ViewModels.MessageViewModels
{
	public class UserMessageViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Mail adresi boş bırakılmamalıdır.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen uygun formatta bir mail adresi giriniz.")]
        public string UserMail { get; set; }


        public string ReceiverMail { get; set; }

        [DisplayName("Konu:")]
        [Required(ErrorMessage = "Konu boş bırakılmamalıdır.")]
        public string Subject { get; set; }

        [DisplayName("Mesaj:")]
        [Required(ErrorMessage = "Mesaj boş bırakılmamalıdır.")]
        public string Content { get; set; }

        [DisplayName("Tarih/Saat:")]
        public DateTime MessageDate { get; set; } = DateTime.Now;
        public bool IsRead { get; set; }
    }
}
