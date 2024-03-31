using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Shared.ComplexTypes
{
	public enum EnumOrderState
	{
		[Display(Name = "Siparişiniz alındı")]
		Received = 0,

		[Display(Name = "Hazırlanıyor")]
		Preparing = 1,

		[Display(Name = "Gönderildi")]
		Sent = 2,

		[Display(Name = "Teslim edildi")]
		Delivered = 3
	}
}
