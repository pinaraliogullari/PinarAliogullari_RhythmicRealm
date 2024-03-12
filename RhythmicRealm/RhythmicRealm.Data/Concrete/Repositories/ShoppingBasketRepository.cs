using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Data.Concrete.Contexts;
using RhythmicRealm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Data.Concrete.Repositories
{
	public class ShoppingBasketRepository:GenericRepository<ShoppingBasket>,IShoppingBasketRepository
	{
		public ShoppingBasketRepository(RRContext _context) : base(_context)
		{

		}
		private RRContext RRContext
		{
			get { return _dbContext as RRContext; }
		}

		
	}
}
