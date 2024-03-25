using Microsoft.EntityFrameworkCore;
using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Data.Concrete.Contexts;
using RhythmicRealm.Entity.Concrete;

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

		public async Task<List<Product>> GetAdvantageousProductsAsync()
		{
			var mainCategories = await RRContext.Products.Select(p => p.SubCategory.MainCategory).Distinct().ToListAsync();
			var filteredProducts = new List<Product>();
			foreach (var mainCategory in mainCategories)
			{
				decimal priceFilter = GetPriceFilterForSubCategory(mainCategory.Name);

				var products = await RRContext.Products
					.Include(p => p.Brand)
					.Include(p => p.SubCategory)
					.ThenInclude(s => s.MainCategory)
					.Where(p => p.SubCategory.MainCategory.Name == mainCategory.Name && p.Price < priceFilter)
					.OrderByDescending(p => p.CreatedDate)
					.ToListAsync();

				if (products != null && products.Any())
				{
					filteredProducts.AddRange(products);
				}
			}

			return filteredProducts;
		}

		private decimal GetPriceFilterForSubCategory(string mainCategoryName)
		{
	
			switch (mainCategoryName)
			{
				case "Tuşlular":
					return 35000; 
				case "Telliler":
					return 10000;
				case "Yaylılar":
					return 30000;
				case "Nefesliler":
					return 1000;
				case "Davul Perküsyon":
					return 6000;
				default:
					return 10000; 
			}
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

		public async Task<List<Product>> GetProductsBySubcategoryIdAndBrandIdAsync(int[] subId, int[] brandId)
		{
			IQueryable<Product> searchResults = RRContext
				.Products
				.Include(p => p.Brand)
				.Include(p => p.SubCategory)
				.ThenInclude(s => s.MainCategory).AsQueryable();

			 if(subId.Length > 0)
				searchResults = searchResults.Where(x => subId.Contains(x.SubCategoryId));
			
			if(brandId.Length > 0)
				searchResults = searchResults.Where(x => brandId.Contains(x.BrandId));

			//Select * from Produıct where SubscatreoID = subcateoryId and BrandId = brandId

			//SElect*from Product where SubcategoryID = subcategoryKId

			return await searchResults.ToListAsync();
		}
	}
}
