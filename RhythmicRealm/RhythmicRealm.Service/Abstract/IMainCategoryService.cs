using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.MainCategoryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Service.Abstract
{
	public interface IMainCategoryService
	{
        Task<Response<List<MainCategoryViewModel>>> GetAllMainCategoriesAsync();
        Task<Response<MainCategoryViewModel>> GetMainCategoryByIdAsync(int id);
        Task<Response<MainCategoryViewModel>> GetMainCategoryWithSubCategoriesAsync(int mainCategoryId);
        Task<Response<List<MainCategoryViewModel>>> GetMainCategoriesByIsActiveAsync();
        Task<Response<List<MainCategoryViewModel>>> GetMainCategoriesByIsDeleteAsync(bool isDeleted = false);
        Task<Response<MainCategoryViewModel>> CreateMainCategoryAsync(AddMainCategoryViewModel addMainCategoryViewModel);
        Task<Response<MainCategoryViewModel>> UpdateMainCategoryAsync(EditMainCategoryViewModel editMainCategoryViewModel);
        Task<bool> UpdateIsActiveAsync(int id);
        Task<Response<NoContent>> SoftDeleteMainCategoryAsync(int id);
        Task<Response<NoContent>> HardDeleteMainCategoryAsync(int id);
       
    }
}
