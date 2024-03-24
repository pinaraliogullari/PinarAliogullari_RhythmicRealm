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
	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
		public ProductRepository(RRContext _context) : base(_context)
		{
		}
		private RRContext RRContext
		{
			get { return _dbContext as RRContext; }
		}

		public async Task<List<Product>> GetProductsByMainCategoryId(int id)
		{
			List<Product> products = await RRContext
			.Products
			.Include(p => p.SubCategory)
			.ThenInclude(s => s.MainCategory)
			.Include(p=>p.Brand)
			.Where(p => p.SubCategory.MainCategoryId == id)
			.ToListAsync();

			return products;
		}

		
	}
}
