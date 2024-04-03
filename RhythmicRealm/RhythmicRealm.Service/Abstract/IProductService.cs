using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.ProductViewModels;

namespace RhythmicRealm.Service.Abstract
{
	public interface IProductService
	{
		Task<Response<List<ProductViewModel>>> GetProductsBySubCategoryIdAsync(int subCategoryId);
		Task<Response<List<ProductViewModel>>> GetProductsByMainCategoryIdAsync(int mainCategoryId); 
		Task<Response<List<ProductViewModel>>> GetNewProductsAsync(); 
		Task<Response<List<ProductViewModel>>> GetAdvantageousProductsAsync(); 
		Task<Response<List<ProductViewModel>>> GetSelectedProducts(); 
		Task<Response<List<ProductViewModel>>> SearchProductAsync(string query); 
		Task<Response<List<ProductViewModel>>> GetProductsByBrandIdAsync(int brandId); 
		Task<Response<ProductViewModel>> GetProductByProductIdAsync(int productId); 
		Task<Response<List<ProductViewModel>>> GetProductsByIsActiveAsync(bool isActive = true);
		Task<Response<List<ProductViewModel>>> GetProductsByIsDeleteAsync(bool isDeleted);
		Task<Response<List<ProductViewModel>>> GetAllProductsAsync(); 
		Task<Response<ProductViewModel>> CreateProductAsync(AddProductViewModel addProductViewModel); 
		Task<Response<ProductViewModel>> UpdateProductAsync(EditProductViewModel editProductDto); 
		Task<Response<NoContent>> HardDeleteAsync(int productId); 
		Task<Response<NoContent>> SoftDeleteAsync(int productId); 
		Task<bool> UpdateIsHomeAsync(int productId); 
		Task<bool> UpdateIsActiveAsync(int productId); 
		Task<Response<List<ProductViewModel>>> GetProductsBySubcategoryIdAndBrandId(int mainCategoryId, int[] subId, int[] brandId); 
	
	
	}
}
