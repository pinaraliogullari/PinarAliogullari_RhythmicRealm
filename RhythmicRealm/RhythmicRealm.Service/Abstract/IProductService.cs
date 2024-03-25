using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Service.Abstract
{
    public interface IProductService
	{
		Task<Response<List<ProductViewModel>>> GetProductsBySubCategoryIdAsync(int subCategoryId);
		Task<Response<List<ProductViewModel>>> GetProductsByMainCategoryIdAsync(int mainCategoryId); //kullandım
		Task<Response<List<ProductViewModel>>> GetNewProductsAsync(); //kullandım
		Task<Response<List<ProductViewModel>>> GetAdvantageousProductsAsync(); //kullandım
		Task<Response<List<ProductViewModel>>> GetSelectedProducts(); //kullandım
		Task<Response<List<ProductViewModel>>> SearchProductAsync(string query); //kullandım
		Task<Response<List<ProductViewModel>>> GetProductsByBrandIdAsync(int brandId); //kullandım
		Task<Response<ProductViewModel>> GetProductByProductIdAsync(int productId); //kullandım
		Task<Response<List<ProductViewModel>>> GetProductsByIsActiveAsync(bool isActive = true);
		Task<Response<List<ProductViewModel>>> GetProductsByIsDeleteAsync(bool isDeleted);
		Task<Response<List<ProductViewModel>>> GetAllProductsAsync(); //kullandım
		Task<Response<ProductViewModel>> CreateProductAsync(AddProductViewModel addProductViewModel); //kullandım
		Task<Response<ProductViewModel>> UpdateProductAsync(EditProductViewModel editProductDto); //kullandım
		Task<Response<NoContent>> HardDeleteAsync(int productId); //kullandım
		Task<Response<NoContent>> SoftDeleteAsync(int productId); //kullandım
		Task<bool> UpdateIsHomeAsync(int productId); //kullandım
		Task<bool> UpdateIsActiveAsync(int productId); //kullandım
		Task<Response<List<ProductViewModel>>> GetProductsBySubcategoryIdAndBrandId(int[] subId, int[] brandId);
	}
}
