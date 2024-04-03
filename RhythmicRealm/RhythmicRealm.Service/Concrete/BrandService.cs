using Mapster;
using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.BrandViewModels;

namespace RhythmicRealm.Service.Concrete
{
	public class BrandService : IBrandService
    {

        private readonly IBrandRepository _brandRepository;
        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<Response<List<BrandViewModel>>> GetAllBrandsAsync()
        {
            var brands = await _brandRepository.GetAllAsync();
            if (brands == null) return Response<List<BrandViewModel>>.Fail(404, "Herhangi bir marka bulunamadı.");
            var brandViewModel = brands.Adapt<List<BrandViewModel>>();
            return Response<List<BrandViewModel>>.Success(brandViewModel, 200);
        }

        public async Task<Response<BrandViewModel>> GetBrandByIdAsync(int id)
        {
            var brand = await _brandRepository.GetAsync(x => x.Id == id);
            if (brand == null) return Response<BrandViewModel>.Fail(404, "Herhangi bir marka bulunamadı.");
            var brandViewModel = brand.Adapt<BrandViewModel>();
            return Response<BrandViewModel>.Success(brandViewModel, 200);
        }

		public async Task<Response<List<BrandSlimViewModel>>> GetBrandsByMainCategoryIdAsync(int mainCategoryId)
		{
			var brands = await _brandRepository
				   .GetAllAsync(b => b.BrandMainCategories.Any(bmc => bmc.MainCategoryId == mainCategoryId));
			var brandViewModels = brands.Select(brand => new BrandSlimViewModel
			{
				Id = brand.Id,
				Name = brand.Name,
				ImageUrl = brand.ImageUrl,
			
			}).ToList();

			return Response<List<BrandSlimViewModel>>.Success(brandViewModels,200);
		}

		
    }
}
