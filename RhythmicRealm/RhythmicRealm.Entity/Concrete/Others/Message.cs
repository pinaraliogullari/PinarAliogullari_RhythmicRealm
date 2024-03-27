using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Entity.Concrete.Others
{
    public class Message
    {
        public int Id { get; set; }
        public string SenderMail { get; set; }
        public string ReceiverMail { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public DateTime MessageDate { get; set; }=DateTime.Now;

        //public int Id { get; set; }
        //public DateTime SendingDate { get; set; } = DateTime.Now;
        //public string Text { get; set; }
        //public string ToId { get; set; }
        //public string ToName { get; set; }
        //public string FromId { get; set; }
        //public string FromName { get; set; }
        //public bool IsRead { get; set; }
    }
}
