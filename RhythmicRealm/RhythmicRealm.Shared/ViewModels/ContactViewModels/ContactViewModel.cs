﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Shared.ViewModels.MessageViewModel
{
	public class ContactViewModel
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string UserMail { get; set; }
		public string Subject { get; set; }
		public string Content { get; set; }
		public DateTime MessageDate { get; set; } = DateTime.Now;
	}
}
