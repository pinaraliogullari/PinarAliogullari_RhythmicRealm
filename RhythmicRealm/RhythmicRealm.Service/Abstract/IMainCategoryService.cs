using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.MainCategoryViewModels;

namespace RhythmicRealm.Service.Abstract
{
	public interface IMainCategoryService
	{
        Task<Response<List<MainCategoryViewModel>>> GetAllMainCategoriesAsync();
        Task<Response<MainCategoryViewModel>> GetMainCategoryByIdAsync(int id);
        Task<Response<MainCategoryViewModel>> GetMainCategoryWithSubCategoriesAsync(int mainCategoryId);
        Task<Response<List<MainCategoryViewModel>>> GetMainCategoriesByIsActiveAsync(bool isActive = true);
        Task<Response<List<MainCategoryViewModel>>> GetMainCategoriesByIsDeleteAsync(bool isDeleted);
        Task<Response<MainCategoryViewModel>> CreateMainCategoryAsync(AddMainCategoryViewModel addMainCategoryViewModel);
        Task<Response<MainCategoryViewModel>> UpdateMainCategoryAsync(EditMainCategoryViewModel editMainCategoryViewModel);
        Task<bool> UpdateIsActiveAsync(int id);
        Task<Response<NoContent>> SoftDeleteMainCategoryAsync(int id);
        Task<Response<NoContent>> HardDeleteMainCategoryAsync(int id);
       
    }
}
