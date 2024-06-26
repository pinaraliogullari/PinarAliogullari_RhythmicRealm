﻿using RhythmicRealm.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Entity.Concrete
{
	public class ShoppingBasketItem
	{
		public int Id { get; set; }
		public int ShoppingBasketId { get; set; }
		public ShoppingBasket ShoppingBasket { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
		public int Quantity { get; set; }
	}
}
