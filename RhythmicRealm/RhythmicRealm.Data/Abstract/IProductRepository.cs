﻿using RhythmicRealm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Data.Abstract
{
	public interface IProductRepository:IGenericRepository<Product>
	{
		Task<List<Product>> GetProductsByMainCategoryIdAsync(int id);
		Task<List<Product>> SearchProductByQueryAsync(string query);
		Task<List<Product>> GetNewProductsAsync();
		Task<List<Product>> GetSelectedProductsAsync();

	}
}
