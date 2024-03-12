using RhythmicRealm.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Entity.Concrete
{
	public class ShoppingBasket:IMainEntity
	{
		public int Id { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public string UserId { get; set; }
		public List<ShoppingBasketItem> ShoppingBasketItems { get; set; } = new List<ShoppingBasketItem>();//sepetin başlangıç durumunu(boş) belirlemek için.
	}
}
