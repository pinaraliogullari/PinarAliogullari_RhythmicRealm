using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.SubCategoryViewModels;
using RhythmicRealm.Shared.ViewModels.SubCategoryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Service.Abstract
{
    public interface ISubCategoryService
	{
        Task<Response<List<SubCategoryViewModel>>> GetAllSubCategoriesAsync(); //kullandım
        Task<Response<SubCategoryViewModel>> GetSubCategoryWithMainCategory(int id);
        Task<Response<List<InSubCategoryViewModel>>> GetSubCategoriesByMainCategoryId(int mainCategoryId); //kullandım

        Task<Response<SubCategoryViewModel>> GetSubCategoryByIdAsync(int id);
        Task<Response<SubCategoryViewModel>> GetSubCategoryWithProductsAsync(int subCategoryId);
        Task<Response<List<SubCategoryViewModel>>> GetSubCategoriesByIsActiveAsync(bool isActive = true);
        Task<Response<List<SubCategoryViewModel>>> GetSubCategoriesByIsDeleteAsync(bool isDeleted = false);
        Task<Response<SubCategoryViewModel>> CreateSubCategoryAsync(AddSubCategoryViewModel addSubCategoryViewModel);//kullandım
		Task<Response<SubCategoryViewModel>> UpdateSubCategoryAsync(EditSubCategoryViewModel editSubCategoryViewModel);//kullandım
		Task<Response<NoContent>> SoftDeleteSubCategoryAsync(int id);//kullandım
		Task<Response<NoContent>> HardDeleteSubCategoryAsync(int id);//kullandım
		Task<bool> UpdateIsActiveAsync(int id); //kullandım
	}
}
