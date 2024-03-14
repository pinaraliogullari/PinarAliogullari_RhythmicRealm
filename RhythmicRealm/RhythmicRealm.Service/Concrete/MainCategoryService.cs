using Mapster;
using RhythmicRealm.Data.Abstract;
using RhythmicRealm.Entity.Concrete;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.MainCategoryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RhythmicRealm.Service.Concrete
{
    public class MainCategoryService : IMainCategoryService
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;

        public MainCategoryService(IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepository = mainCategoryRepository;
        }

        public async Task<Response<MainCategoryViewModel>> CreateMainCategoryAsync(AddMainCategoryViewModel addMainCategoryViewModel)
        {
            var mainCategory= addMainCategoryViewModel.Adapt<MainCategory> ();
            if (mainCategory == null)
                return Response<MainCategoryViewModel>.Fail(400, "İşlem başarısız");
            await _mainCategoryRepository.CreateAsync (mainCategory);
            var mainCategoryViewModel=mainCategory.Adapt<MainCategoryViewModel> ();
            return Response<MainCategoryViewModel>.Success(mainCategoryViewModel, 200);
        }

        public Task<Response<List<MainCategoryViewModel>>> GetAllMainCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public  Task<Response<List<MainCategoryViewModel>>> GetMainCategoriesByIsActiveAsync()
        {
            throw new NotImplementedException();
          
        }

        public async Task<Response<List<MainCategoryViewModel>>> GetMainCategoriesByIsDeleteAsync(bool isDeleted = false)
        {
           var mainCategories=await _mainCategoryRepository.GetAllAsync(m=>m.IsDeleted== isDeleted);
            if (mainCategories == null)
                return Response<List<MainCategoryViewModel>>.Fail(404, "Sonuç bulunamadı");
            var mainCategoryViewModel=mainCategories.Adapt<List<MainCategoryViewModel>>();
            return Response<List<MainCategoryViewModel>>.Success(mainCategoryViewModel, 200);
        }

        public async Task<Response<MainCategoryViewModel>> GetMainCategoryByIdAsync(int id)
        {
            var mainCategory = await _mainCategoryRepository.GetAsync(m => m.Id == id);
            if (mainCategory == null)
                return Response<MainCategoryViewModel>.Fail(404, "Sonuç bulunamadı");
            var mainCategoryViewModel=mainCategory.Adapt<MainCategoryViewModel>();
            return Response<MainCategoryViewModel>.Success(mainCategoryViewModel, 200);
        }

        public Task<Response<MainCategoryViewModel>> GetMainCategoryWithSubCategoriesAsync(int mainCategoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<NoContent>> HardDeleteMainCategoryAsync(int id)
        {
            var mainCategory= await _mainCategoryRepository.GetAsync(m=>m.Id==id);
            if (mainCategory == null)
                return Response<NoContent>.Fail(404, "Sonuç bulunamadı");
            await _mainCategoryRepository.HardDeleteAsync(mainCategory);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<NoContent>> SoftDeleteMainCategoryAsync(int id)
        {
           var mainCategory=await _mainCategoryRepository.GetAsync(m=>m.Id==id);
            if (mainCategory == null)
                return Response<NoContent>.Fail(404, "Sonuç bulunamadı");
            mainCategory.IsDeleted=!mainCategory.IsDeleted;
            mainCategory.UpdatedDate = DateTime.Now;
            await _mainCategoryRepository.UpdateAsync(mainCategory);
            return Response<NoContent>.Success(200);
        }

        public async Task<bool> UpdateIsActiveAsync(int id)
        {
            var mainCategory= await _mainCategoryRepository.GetAsync(m=>m.Id==id);
            mainCategory.IsActive = !mainCategory.IsActive;
            mainCategory.UpdatedDate = DateTime.Now;
            await _mainCategoryRepository.UpdateAsync(mainCategory);
            return mainCategory.IsActive;
        }

        public async Task<Response<MainCategoryViewModel>> UpdateMainCategoryAsync(EditMainCategoryViewModel editMainCategoryViewModel)
        {
            var mainCategory = editMainCategoryViewModel.Adapt<MainCategory>();
            if (mainCategory == null)
                return Response<MainCategoryViewModel>.Fail(404, "Sonuç bulunamadı");
            mainCategory.UpdatedDate= DateTime.Now;
            await _mainCategoryRepository.UpdateAsync(mainCategory);
            var mainCategoryViewModel=mainCategory.Adapt<MainCategoryViewModel>();
            return Response<MainCategoryViewModel>.Success(mainCategoryViewModel, 200);

        }

     
    }
}
