using RhythmicRealm.Shared.Response;
using RhythmicRealm.UI.ViewModels.SubCategoryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Service.Abstract
{
    public interface ISubCategoryService
	{
        Task<Response<List<SubCategoryViewModel>>> GetAllSubCategoriesAsync();
        Task<Response<SubCategoryViewModel>> GetSubCategoryByIdAsync(int id);
        Task<Response<SubCategoryViewModel>> GetSubCategoryWithProductsAsync(int subCategoryId);
        Task<Response<List<SubCategoryViewModel>>> GetSubCategoriesByIsActiveAsync(bool isActive = true);
        Task<Response<List<SubCategoryViewModel>>> GetSubCategoriesByIsDeleteAsync(bool isDeleted = false);
        Task<Response<SubCategoryViewModel>> CreateSubCategoryAsync(AddSubCategoryViewModel addSubCategoryViewModel);
        Task<Response<SubCategoryViewModel>> UpdateSubCategoryAsync(EditSubCategoryViewModel editSubCategoryViewModel);
        Task<Response<NoContent>> SoftDeleteSubCategoryAsync(int id);
        Task<Response<NoContent>> HardDeleteSubCategoryAsync(int id);
    }
}
