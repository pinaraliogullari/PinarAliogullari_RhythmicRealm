﻿using Mapster;
using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Service.Concrete;
using RhythmicRealm.Shared.ViewModels.BrandViewModels;
using RhythmicRealm.Shared.ViewModels.MainCategoryViewModels;
using RhythmicRealm.Shared.ViewModels.ProductViewModels;
using RhythmicRealm.UI.Areas.Admin.AdminViewModels;
using RhythmicRealm.UI.ViewModels.SubCategoryViewModels;

namespace RhythmicRealm.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MainCategoryController : Controller
    {
        private readonly IMainCategoryService _mainCategoryService;

        public MainCategoryController(IMainCategoryService mainCategoryService)
        {
            _mainCategoryService = mainCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(bool isdeleted)
        {
            var mainCategories = await _mainCategoryService.GetMainCategoriesByIsDeleteAsync(isdeleted);

            ViewBag.TransferInf = isdeleted;
            TempData["TransferInf"] = isdeleted;
            return View(mainCategories.Data);

        }

        [HttpGet]
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            var result = await _mainCategoryService.UpdateIsActiveAsync(id);
            return Json(result);

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var mainCategory = await _mainCategoryService.GetMainCategoryByIdAsync(id);
            var mainCategoryViewModel = mainCategory.Data;
            var model = mainCategoryViewModel.Adapt<AdminDeleteMainCategoryViewModel>();
            return PartialView("_DeleteMainCategoryPartialView", model);
        }

        [HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {

            await _mainCategoryService.HardDeleteMainCategoryAsync(id);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _mainCategoryService.SoftDeleteMainCategoryAsync(id);
            var tempdataInf = TempData["TransferInf"];
            return RedirectToAction("Index", new { isdeleted = tempdataInf });
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var mainCategory = await _mainCategoryService.GetMainCategoryByIdAsync(id);
            var mainCategoryViewModel=mainCategory.Data;
            var model= mainCategoryViewModel.Adapt<EditMainCategoryViewModel>();
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditMainCategoryViewModel editMainCategoryViewModel)
        {

            if (ModelState.IsValid)
            {
                await _mainCategoryService.UpdateMainCategoryAsync(editMainCategoryViewModel);
                return RedirectToAction("Index");
            }

            return View(editMainCategoryViewModel);

        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
         
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddMainCategoryViewModel addMainCategoryViewModel)
        {
            if(ModelState.IsValid)
            {
                await _mainCategoryService.CreateMainCategoryAsync(addMainCategoryViewModel);
                return RedirectToAction("Index");
            }
            return View(addMainCategoryViewModel);
        }

 

    }

}
