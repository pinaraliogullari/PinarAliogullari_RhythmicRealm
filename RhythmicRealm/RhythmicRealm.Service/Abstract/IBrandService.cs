using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.BrandViewModels;

namespace RhythmicRealm.Service.Abstract
{
	public interface IBrandService
	{
        Task<Response<BrandViewModel>> GetBrandByIdAsync(int id);
        Task<Response<List<BrandViewModel>>> GetAllBrandsAsync();
        Task<Response<List<BrandSlimViewModel>>> GetBrandsByMainCategoryIdAsync(int mainCategoryId);
    }
}
