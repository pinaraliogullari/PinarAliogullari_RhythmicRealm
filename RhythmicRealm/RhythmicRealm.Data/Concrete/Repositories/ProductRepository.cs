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

		public async Task<List<Product>> GetNewProductsAsync()
		{
			var startDate = DateTime.Today.AddDays(-3);
			var newProducts = await RRContext
				.Products
				.Include(p => p.Brand)
				.Include(p => p.SubCategory)
				.ThenInclude(s => s.MainCategory)
			    .Where(p => p.CreatedDate >= startDate)
				.ToListAsync();

			return newProducts;
		}

		public async Task<List<Product>> GetProductsByMainCategoryIdAsync(int id)
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

		public async Task<List<Product>> GetSelectedProductsAsync()
		{
			var selectedProducts=new List<Product>();
			var subCategories = await RRContext.Products.Select(p => p.SubCategory).Distinct().ToListAsync();
			foreach (var subCategory in subCategories)
			{
				var product = await RRContext.Products
					.Include(p => p.SubCategory)
					.ThenInclude(s => s.MainCategory)
					.Include(p => p.Brand)
					.Where(p => p.SubCategoryId == subCategory.Id)
					.OrderByDescending(p => p.CreatedDate)
					.FirstOrDefaultAsync();
				if(product != null)
				{
					 selectedProducts.Add(product);
				}
			}
			return selectedProducts;
		}

		public async Task<List<Product>> SearchProductByQueryAsync(string query)
		{
			var searchResults = await RRContext
				.Products
				.Include(p => p.Brand)
				.Include (p => p.SubCategory)
				.ThenInclude (s => s.MainCategory)
		        .Where(p => p.Name.Contains(query.ToUpper()) || p.Description.Contains(query.ToUpper()) || p.Brand.Name.Contains(query.ToUpper()))
		        .ToListAsync();
			return searchResults;
		}
	}
}
