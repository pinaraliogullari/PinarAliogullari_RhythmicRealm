using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.BrandViewModels;
using RhythmicRealm.Shared.ViewModels.BrandViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Service.Abstract
{
    public interface IBrandService
	{
        Task<Response<BrandViewModel>> GetBrandByIdAsync(int id);
        Task<Response<List<BrandViewModel>>> GetAllBrandsAsync();
        Task<Response<BrandViewModel>> GetBrandWithMainCategoriesAsync(int brandId);
        Task<Response<List<BrandSlimViewModel>>> GetBrandsByMainCategoryId(int mainCategoryId);
    }
}
