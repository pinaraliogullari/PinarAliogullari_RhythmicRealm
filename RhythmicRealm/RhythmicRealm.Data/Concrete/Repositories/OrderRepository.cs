using Microsoft.EntityFrameworkCore;
using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Data.Concrete.Contexts;
using RhythmicRealm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Data.Concrete.Repositories
{
	public class OrderRepository:GenericRepository<Order>,IOrderRepository
	{
		public OrderRepository(RRContext _context) : base(_context)
		{

		}
		private RRContext RRContext
		{
			get { return _dbContext as RRContext; }
		}

		public async Task<List<Order>> GetAllOrdersByProductIdAsync(int productId)
		{
			var orders = await RRContext.Orders
				.Include(x => x.OrderItems)
				.ThenInclude(x => x.Product)
				.Where(x => x.OrderItems.Any(x => x.ProductId == productId))
				.OrderByDescending(x => x.Id)
				.ToListAsync();
			return orders;
		}
	}
}
