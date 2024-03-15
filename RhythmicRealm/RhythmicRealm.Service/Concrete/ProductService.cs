using Mapster;
using Microsoft.EntityFrameworkCore;
using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Entity.Concrete;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels;
using RhythmicRealm.Shared.ViewModels.BrandViewModels;
using RhythmicRealm.Shared.ViewModels.MainCategoryViewModels;
using RhythmicRealm.Shared.ViewModels.ProductViewModels;
using RhythmicRealm.Shared.ViewModels.SubCategoryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Service.Concrete
{
    public class ProductService:IProductService
	{

		private readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public Task<Response<ProductViewModel>> CreateProductAsync(AddProductViewModel addProductViewModel)
		{
			throw new NotImplementedException();
		}

		public Task<Response<List<ProductViewModel>>> GetAllProductsAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<Response<ProductViewModel>> GetProductByProductIdAsync(int productId)
		{
            var product = await _productRepository.GetAsync(p => p.Id == productId, p => p.Include(x => x.Brand).Include(x => x.SubCategory).ThenInclude(x => x.MainCategory));
            if (product == null) return Response<ProductViewModel>.Fail(404, "Sonuç bulunamadı");
            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                ImageUrl = product.ImageUrl,
                Url = product.Url,
                Description = product.Description,
                Properties = product.Properties,
                Price = product.Price,
                IsActive = product.IsActive,
                IsHome = product.IsHome,
                MainCategory = new InMainCategoryViewModel
                {
                    Id = product.SubCategory.MainCategory.Id,
                    Name = product.SubCategory.MainCategory.Name,
                    IsActive = product.SubCategory.MainCategory.IsActive,
                    IsDeleted = product.SubCategory.MainCategory.IsDeleted,
                    Url = product.SubCategory.MainCategory.Url,


                },
                SubCategory = new InSubCategoryViewModel
                {
                    Id = product.SubCategory.Id,
                    Name = product.SubCategory.Name,
                    IsActive = product.SubCategory.IsActive,
                    IsDeleted = product.SubCategory.IsDeleted,
                    Url = product.SubCategory.Url
                },
                Brand = new BrandSlimViewModel
                {
                    Id = product.Brand.Id,
                    Name = product.Brand.Name,

                }
            };
            return Response<ProductViewModel>.Success(productViewModel, 200);
        }

		public Task<Response<List<ProductViewModel>>> GetProductsByIsActiveAsync(bool isActive = true)
		{
			throw new NotImplementedException();
		}



		/// <summary>
		/// Bu metot; verilen parametredeki değere göre silinmiş veya silinmemiş productları listeler.
		/// </summary>
		/// <param name="productId"></param>
		/// <returns></returns>
		public async Task<Response<List<ProductViewModel>>> GetProductsByIsDeleteAsync(bool isDeleted)
		{
			
			var products = await _productRepository.GetAllAsync (p => p.IsDeleted == isDeleted, p => p.Include(x => x.Brand).Include(x => x.SubCategory).ThenInclude(x => x.MainCategory));
			if (products == null) return Response<List<ProductViewModel>>.Fail(404, "Sonuç bulunamadı");
			var productsDto = products.Select(product => new ProductViewModel
			{
				Id = product.Id,
				Name = product.Name,
				ImageUrl = product.ImageUrl,
				Url = product.Url,
				Description = product.Description,
				Properties = product.Properties,
				Price = product.Price,
				IsActive = product.IsActive,
				IsHome = product.IsHome,
				MainCategory = new InMainCategoryViewModel
				{
					Id = product.SubCategory.MainCategory.Id,
					Name = product.SubCategory.MainCategory.Name,
					IsActive = product.SubCategory.MainCategory.IsActive,
					IsDeleted = product.SubCategory.MainCategory.IsDeleted,
					Url = product.SubCategory.MainCategory.Url,


				},
				SubCategory = new InSubCategoryViewModel
				{
					Id = product.SubCategory.Id,
					Name = product.SubCategory.Name,
					IsActive = product.SubCategory.IsActive,
					IsDeleted = product.SubCategory.IsDeleted,
					Url = product.SubCategory.Url
				},
				Brand = new BrandSlimViewModel
				{
					Id = product.Brand.Id,
					Name = product.Brand.Name,

				}
			}).ToList();
			return Response<List<ProductViewModel>>.Success(productsDto, 200);
		}

		public Task<Response<List<ProductViewModel>>> GetProductsBySubCategoryIdAsync(int subCategoryId)
		{
			throw new NotImplementedException();
		}

		public async Task<Response<NoContent>> HardDeleteAsync(int productId)
		{
			var product= await _productRepository.GetAsync(p=>p.Id==productId);
			if (product == null) return Response<NoContent>.Fail(404, "Ürün bulunamadı");
			await _productRepository.HardDeleteAsync(product);
			return Response<NoContent>.Success(200);
		}

		public async Task<Response<NoContent>> SoftDeleteAsync(int productId)
		{
            var product = await _productRepository.GetAsync(p => p.Id == productId);
            if (product == null) return Response<NoContent>.Fail(404, "Ürün bulunamadı");
			product.IsDeleted=!product.IsDeleted;
			product.UpdatedDate = DateTime.Now;
            await _productRepository.UpdateAsync(product);
            return Response<NoContent>.Success(200);
        }

		public async Task<bool> UpdateIsActiveAsync(int productId)
		{
			var product= await _productRepository.GetAsync(p=>p.Id == productId);
			product.IsActive =!product.IsActive;
			product.UpdatedDate= DateTime.Now;
			await _productRepository.UpdateAsync(product);
			return product.IsActive;
		}

		public async Task<bool> UpdateIsHomeAsync(int productId)
		{
            var product = await _productRepository.GetAsync(p => p.Id == productId);
            product.IsHome = !product.IsHome;
            product.UpdatedDate = DateTime.Now;
            await _productRepository.UpdateAsync(product);
            return product.IsHome;
        }

		public async Task<Response<ProductViewModel>> UpdateProductAsync(EditProductViewModel editProductViewModel)
		{
            var editedProduct = editProductViewModel.Adapt<Product>();
            if (editedProduct == null)
            {
                return Response<ProductViewModel>.Fail(404, "Güncellenecek ürün bulunamadı");
            }
            editedProduct.UpdatedDate = DateTime.Now;
            await _productRepository.UpdateAsync(editedProduct);
            var brandMainCategory = new BrandMainCategory
            {
                BrandId = editedProduct.BrandId
            };

            await _productRepository.UpdateAsync(editedProduct);
            var resultProduct = editedProduct.Adapt<ProductViewModel>();
            return Response<ProductViewModel>.Success(resultProduct, 200);
        }
	}
}
