using Mapster;
using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.ViewModels.MainCategoryViewModels;
using RhythmicRealm.UI.Areas.Admin.AdminViewModels;

namespace RhythmicRealm.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {

        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(bool isdeleted)
        {
            var subCategories = await _subCategoryService.GetSubCategoriesByIsDeleteAsync(isdeleted);

            ViewBag.TransferInf = isdeleted;
            TempData["TransferInf"] = isdeleted;
            return View(subCategories.Data);

        }

        [HttpGet]
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            var result = await _subCategoryService.UpdateIsActiveAsync(id);
            return Json(result);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var subCategory = await _subCategoryService.GetSubCategoryByIdAsync(id);
            var subCategoryViewModel = subCategory.Data;
            var adminSubCategoryDeleteViewModel = new AdminSubCategoryDeleteViewModel
            {
                Id = subCategoryViewModel.Id,
                Name = subCategoryViewModel.Name,
                Url = subCategoryViewModel.Url

            };
            return PartialView("_DeleteSubCategoryPartialView", adminSubCategoryDeleteViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {

            await _subCategoryService.HardDeleteSubCategoryAsync(id);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _subCategoryService.SoftDeleteSubCategoryAsync(id);
            var tempdataInf = TempData["TransferInf"];
            return RedirectToAction("Index", new { isdeleted = tempdataInf });
        }



        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{

        //    var mainCategory = await _subCategoryService.GetMainCategoryByIdAsync(id);
        //    var mainCategoryViewModel = mainCategory.Data;
        //    var model = mainCategoryViewModel.Adapt<EditMainCategoryViewModel>();
        //    return View(model);

        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(EditMainCategoryViewModel editMainCategoryViewModel)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        await _subCategoryService.UpdateMainCategoryAsync(editMainCategoryViewModel);
        //        return RedirectToAction("Index");
        //    }

        //    return View(editMainCategoryViewModel);

        //}


        //[HttpGet]
        //public async Task<IActionResult> Create()
        //{

        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Create(AddMainCategoryViewModel addMainCategoryViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _subCategoryService.CreateMainCategoryAsync(addMainCategoryViewModel);
        //        return RedirectToAction("Index");
        //    }
        //    return View(addMainCategoryViewModel);
        //}


    }

}
