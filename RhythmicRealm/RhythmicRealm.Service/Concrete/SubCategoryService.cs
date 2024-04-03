using Mapster;
using Microsoft.EntityFrameworkCore;
using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Entity.Concrete;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.BrandViewModels;
using RhythmicRealm.Shared.ViewModels.MainCategoryViewModels;
using RhythmicRealm.Shared.ViewModels.ProductViewModels;
using RhythmicRealm.Shared.ViewModels.SubCategoryViewModels;


namespace RhythmicRealm.Service.Concrete
{
	public class SubCategoryService:ISubCategoryService
	{
        private readonly ISubCategoryRepository _subCategoryRepository;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository)
            {
                _subCategoryRepository = subCategoryRepository;
            }

        public async Task<Response<SubCategoryViewModel>> CreateSubCategoryAsync(AddSubCategoryViewModel addSubCategoryViewModel)
            {
                var subCategory = addSubCategoryViewModel.Adapt<SubCategory>();
                var createdSubCategory = await _subCategoryRepository.CreateAsync(subCategory);
                if (createdSubCategory == null)
                    return Response<SubCategoryViewModel>.Fail(404, "Alt kategori kaydedilirken bir hata meydana geldi.");

                var subCategoryDTO = createdSubCategory.Adapt<SubCategoryViewModel>();
                return Response<SubCategoryViewModel>.Success(subCategoryDTO, 200);
            }

        public async Task<Response<List<SubCategoryViewModel>>> GetAllSubCategoriesAsync()
            {
                var subCategories = await _subCategoryRepository.GetAllAsync();
                if (subCategories == null) return Response<List<SubCategoryViewModel>>.Fail(404, "Sonuç bulunamadı");
                var subCategoriesViewModel = subCategories.Select(subCategory => new SubCategoryViewModel
                {
                    Id = subCategory.Id,
                    Name = subCategory.Name,
                    IsActive = subCategory.IsActive,
                    IsDeleted = subCategory.IsDeleted,
                    Url = subCategory.Url
                }).ToList();
                return Response<List<SubCategoryViewModel>>.Success(subCategoriesViewModel, 200);
            }

        public async Task<Response<List<SubCategoryViewModel>>> GetSubCategoriesByIsActiveAsync(bool isActive = true)
            {
                var subCategories = await _subCategoryRepository.GetAllAsync(s => s.IsActive == isActive);
                if (subCategories == null) return Response<List<SubCategoryViewModel>>.Fail(404, "Sonuç bulunamadı");
                var subCategoriesViewModel = subCategories.Adapt<List<SubCategoryViewModel>>();
                return Response<List<SubCategoryViewModel>>.Success(subCategoriesViewModel, 200);
            }

        public async Task<Response<List<SubCategoryViewModel>>> GetSubCategoriesByIsDeleteAsync(bool isDeleted = false)
            {
                var subCategories = await _subCategoryRepository.GetAllAsync(s => s.IsDeleted == isDeleted,
                    IncludeExpression=> IncludeExpression
					.Include(s=>s.MainCategory));
                if (subCategories == null) return Response<List<SubCategoryViewModel>>.Fail(404, "Sonuç bulunamadı");
            var subCategoriesViewModel = subCategories.Select(subCategory => new SubCategoryViewModel
            {
                Id = subCategory.Id,
                Name = subCategory.Name,
                Url = subCategory.Url,
                IsActive = subCategory.IsActive,
                IsDeleted = subCategory.IsDeleted,
                MainCategory = new MainCategorySlimViewModel
                {
                    Id = subCategory.MainCategory.Id,
                    Name = subCategory.MainCategory.Name,
                },

            }).ToList();
                return Response<List<SubCategoryViewModel>>.Success(subCategoriesViewModel, 200);
            }

		public async Task<Response<List<InSubCategoryViewModel>>> GetSubCategoriesByMainCategoryId(int mainCategoryId)
		{
            var subCategories = await _subCategoryRepository.GetAllAsync(s => s.MainCategoryId == mainCategoryId);
			if (subCategories == null) return Response<List<InSubCategoryViewModel>>.Fail(404, "İlgili ana kategori bulunamadı.");
			var subCategoryViewModels = subCategories.Select(subCategory => new InSubCategoryViewModel
			{
				Id = subCategory.Id,
				Name = subCategory.Name,
                IsActive=subCategory.IsActive,
                IsDeleted = subCategory.IsDeleted,
                Url = subCategory.Url,
			}).ToList();
			return Response<List<InSubCategoryViewModel>>.Success(subCategoryViewModels, 200);
		}

		public async Task<Response<SubCategoryViewModel>> GetSubCategoryByIdAsync(int id)
            {
                var subCategory = await _subCategoryRepository.GetAsync(s => s.Id == id);
                if (subCategory == null) return Response<SubCategoryViewModel>.Fail(404, "İlgili ana kategori bulunamadı.");
                var subCategoriesViewModel = subCategory.Adapt<SubCategoryViewModel>();
                return Response<SubCategoryViewModel>.Success(subCategoriesViewModel, 200);
            }

        public async Task<Response<SubCategoryViewModel>> GetSubCategoryWithMainCategory(int id)
        {
            var subCategory = await _subCategoryRepository.GetAsync(s => s.Id == id,x=>x.Include(s=>s.MainCategory));
            if (subCategory == null) return Response<SubCategoryViewModel>.Fail(404, "İlgili ana kategori bulunamadı.");
            var subCategoryViewModel = new SubCategoryViewModel
            {
                Id = subCategory.Id,
                Name = subCategory.Name,
                IsActive = subCategory.IsActive,
                IsDeleted = subCategory.IsDeleted,
                Url = subCategory.Url,
                MainCategory = new MainCategorySlimViewModel
                {
                    Id = subCategory.MainCategory.Id,
                    Name = subCategory.MainCategory.Name,
                }
            };
            return Response<SubCategoryViewModel>.Success(subCategoryViewModel, 200);
        }

        public async Task<Response<SubCategoryViewModel>> GetSubCategoryWithProductsAsync(int subCategoryId)
            {
                var subCategory = await _subCategoryRepository.GetAsync(s => s.Id == subCategoryId,
                 source => source
                .Include(s => s.Products).ThenInclude(s => s.Brand));

                if (subCategory == null)
                    return Response<SubCategoryViewModel>.Fail(404, "Sonuç bulunamadı");

                var subCategoryViewModel = new SubCategoryViewModel
                {
                    Id = subCategory.Id,
                    Name = subCategory.Name,
                    IsActive = subCategory.IsActive,
                    IsDeleted = subCategory.IsDeleted,
                    Url = subCategory.Url,
                    Products = subCategory.Products.Select(p => new InProductViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        IsActive = p.IsActive,
                        Url = p.Url,
                        ImageUrl = p.ImageUrl,
                        Description = p.Description,
                        Properties = p.Properties,
                        IsHome = p.IsHome,
                        Price = p.Price
                    }).ToList(),
                    Brands = subCategory.Products.Select(x => new BrandSlimViewModel
                    {
                        Id = x.Brand.Id,
                        Name = x.Brand.Name,
                    }).ToList(),
                };

                var brands = subCategory.Products.Select(x => x.Brand).ToList();
                return Response<SubCategoryViewModel>.Success(subCategoryViewModel, 200);
            }

        public async Task<Response<NoContent>> HardDeleteSubCategoryAsync(int id)
            {
                var subCategory = await _subCategoryRepository.GetAsync(s => s.Id == id);
                if (subCategory == null) return Response<NoContent>.Fail(404, "Sonuç bulunamadı");
                await _subCategoryRepository.HardDeleteAsync(subCategory);
                return Response<NoContent>.Success(200);
            }

        public async Task<Response<NoContent>> SoftDeleteSubCategoryAsync(int id)
            {
                var subCategory = await _subCategoryRepository.GetAsync(s => s.Id == id);
                if (subCategory == null) return Response<NoContent>.Fail(404, "Sonuç bulunamadı");
                subCategory.IsDeleted = !subCategory.IsDeleted;
                subCategory.IsActive = false;
                subCategory.UpdatedDate = DateTime.Now;
                await _subCategoryRepository.UpdateAsync(subCategory);
                return Response<NoContent>.Success(200);
            }

        public async Task<bool> UpdateIsActiveAsync(int id)
        {
            var subCategory = await _subCategoryRepository.GetAsync(s => s.Id == id);
            subCategory.IsActive = !subCategory.IsActive;
            subCategory.UpdatedDate = DateTime.Now;
            await _subCategoryRepository.UpdateAsync(subCategory);
            return subCategory.IsActive;
        }

        public async Task<Response<SubCategoryViewModel>> UpdateSubCategoryAsync(EditSubCategoryViewModel editSubCategoryViewModel)
            {
                var subCategory = new SubCategory
                {
                    Id = editSubCategoryViewModel.Id,
                    Name = editSubCategoryViewModel.Name,
                    Url = editSubCategoryViewModel.Url,
                    IsActive = editSubCategoryViewModel.IsActive,
                    MainCategoryId = editSubCategoryViewModel.MainCategories.Id,
                };
                if (subCategory == null) return Response<SubCategoryViewModel>.Fail(404, "Sonuç bulunamadı");
                await _subCategoryRepository.UpdateAsync(subCategory);
                var subCategoryViewModel = new SubCategoryViewModel
                {
                    Id = subCategory.Id,
                    Name = subCategory.Name,
                    Url = subCategory.Url,
                    IsActive = subCategory.IsActive,
                    IsDeleted = subCategory.IsDeleted,


                };
                return Response<SubCategoryViewModel>.Success(subCategoryViewModel, 200);
            }
        }
    }

