using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels;
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
	}
}
