using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Shared.ViewModels.MessageViewModels
{
    public class MessageViewModel
    {
        public int Id { get; set; }


        [DisplayName("Kimden:")]
        public string SenderMail { get; set; }

        [DisplayName("Kime:")]
        [Required(ErrorMessage = "Alıcı adresi boş bırakılmamalıdır.")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Lütfen uygun formatta bir mail adresi giriniz.")]
        public string ReceiverMail { get; set; }

        [DisplayName("Konu:")]
        [Required(ErrorMessage = "Konu boş bırakılmamalıdır.")]
        public string Subject { get; set; }

        [DisplayName("Mesaj:")]
        [Required(ErrorMessage = "Mesaj boş bırakılmamalıdır.")]
        public string Content { get; set; }

        [DisplayName("Tarih/Saat:")]
        public DateTime MessageDate { get; set; } = DateTime.Now;
    }
}
