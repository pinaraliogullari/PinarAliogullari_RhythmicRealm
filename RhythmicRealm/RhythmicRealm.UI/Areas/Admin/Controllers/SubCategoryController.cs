using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Shared.ViewModels.MainCategoryViewModels;
using RhythmicRealm.Shared.ViewModels.SubCategoryViewModels;
using RhythmicRealm.UI.Areas.Admin.AdminViewModels;

namespace RhythmicRealm.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SubCategoryController : Controller
	{

		private readonly ISubCategoryService _subCategoryService;
		private readonly IMainCategoryService _mainCategoryService;
		private readonly INotyfService _notyfService;

		public SubCategoryController(ISubCategoryService subCategoryService, IMainCategoryService mainCategoryService, INotyfService notyfService)
		{
			_subCategoryService = subCategoryService;
			_mainCategoryService = mainCategoryService;
			_notyfService = notyfService;
		}

		[HttpGet]
		public async Task<IActionResult> Index(bool isdeleted)
		{
			var subCategories = await _subCategoryService.GetSubCategoriesByIsDeleteAsync(isdeleted);

			ViewBag.TransferInf = isdeleted;
			TempData["TransferInf"] = isdeleted;
			return View(subCategories.Data);

		}


		[Authorize(Roles = "SuperAdmin,Admin")]
		[HttpGet]
		public async Task<IActionResult> UpdateIsActive(int id)
		{
			var result = await _subCategoryService.UpdateIsActiveAsync(id);
			return Json(result);

		}


		[Authorize(Roles = "SuperAdmin,Admin")]
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


		[Authorize(Roles = "SuperAdmin,Admin")]
		[HttpGet]
		public async Task<IActionResult> HardDelete(int id)
		{

			await _subCategoryService.HardDeleteSubCategoryAsync(id);
			_notyfService.Success("Alt kategori kalıcı olarak silindi.");
			return RedirectToAction("Index");

		}


		[Authorize(Roles = "SuperAdmin,Admin")]
		[HttpGet]
		public async Task<IActionResult> SoftDelete(int id)
		{
			await _subCategoryService.SoftDeleteSubCategoryAsync(id);
			var tempdataInf = TempData["TransferInf"];
			if (tempdataInf != null && tempdataInf is bool transferInf && transferInf == true)

				_notyfService.Information("Ürün çöp kutusundan çıkartıldı.");

			else
				_notyfService.Information("Ürün çöp kutusuna gönderildi.");
			return RedirectToAction("Index", new { isdeleted = tempdataInf });
		}

		private async Task<List<MainCategoryViewModel>> GetMainCategories()
		{
			var mainCategories = await _mainCategoryService.GetAllMainCategoriesAsync();
			return mainCategories.Data;
		}


		[Authorize(Roles = "SuperAdmin,Admin")]
		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{

			var subCategory = await _subCategoryService.GetSubCategoryWithMainCategory(id);
			var subCategoryViewModel = subCategory.Data;
			var mainCategories = await GetMainCategories();

			var mainCategoryListItem = mainCategories.Select(x => new SelectListItem
			{
				Value = x.Id.ToString(),
				Text = x.Name,
			}).ToList();
			var editSubCategoryViewModel = new EditSubCategoryViewModel
			{
				Id = subCategoryViewModel.Id,
				Name = subCategoryViewModel.Name,
				Url = subCategoryViewModel.Url,
				IsActive = subCategoryViewModel.IsActive,

			};
			var model = new AdminEditSubCategoryViewModel
			{
				EditSubCategoryViewModel = editSubCategoryViewModel,
				MainCategoryList = mainCategoryListItem,
				MainCategoryId = subCategoryViewModel.MainCategory.Id,
				MainCategoryName = subCategoryViewModel.MainCategory.Name,

			};
			return View(model);

		}

		[HttpPost]
		public async Task<IActionResult> Edit(AdminEditSubCategoryViewModel adminEditSubCategoryViewModel)
		{

			ModelState.Remove("EditSubCategoryViewModel.MainCategories.Name");
			if (ModelState.IsValid)
			{
				var editSubCategoryViewModel = new EditSubCategoryViewModel
				{
					Id = adminEditSubCategoryViewModel.EditSubCategoryViewModel.Id,
					Name = adminEditSubCategoryViewModel.EditSubCategoryViewModel.Name,
					Url = adminEditSubCategoryViewModel.EditSubCategoryViewModel.Url,
					IsActive = adminEditSubCategoryViewModel.EditSubCategoryViewModel.IsActive,
					MainCategories = new MainCategorySlimViewModel
					{
						Id = adminEditSubCategoryViewModel.MainCategoryId,
						Name = adminEditSubCategoryViewModel.MainCategoryName
					}

				};
				await _subCategoryService.UpdateSubCategoryAsync(editSubCategoryViewModel);
				_notyfService.Success("Ana kategori başarıyla güncellendi.");
				return RedirectToAction("Index");
			}
			var mainCategories = await GetMainCategories();
			var mainCategoryListItem = mainCategories.Select(x => new SelectListItem
			{
				Value = x.Id.ToString(),
				Text = x.Name,
			}).ToList();
			adminEditSubCategoryViewModel.MainCategoryList = mainCategoryListItem;
			_notyfService.Error("Alt kategori güncellenşrken bir sorun oluştu.");
			return View(adminEditSubCategoryViewModel);

		}


		[Authorize(Roles = "SuperAdmin,Admin")]
		[HttpGet]
		public async Task<IActionResult> Create()
		{
			var model = new AdminAddSubCategoryViewModel();
			var mainCategories = await GetMainCategories();

			var mainCategoryListItem = mainCategories.Select(x => new SelectListItem
			{
				Value = x.Id.ToString(),
				Text = x.Name,
			}).ToList();
			model.MainCategoryList = mainCategoryListItem;
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> Create(AdminAddSubCategoryViewModel adminAddSubCategoryViewModel)
		{
			
			var model = new AddSubCategoryViewModel
			{
				Name = adminAddSubCategoryViewModel.AddSubCategoryViewModel.Name,
				Url = adminAddSubCategoryViewModel.AddSubCategoryViewModel.Url,
				IsActive = adminAddSubCategoryViewModel.AddSubCategoryViewModel.IsActive,
				MainCategoryId = adminAddSubCategoryViewModel.MainCategoryId
			};
			await _subCategoryService.CreateSubCategoryAsync(model);
			_notyfService.Success("Alt kategori başarıyla kaydedildi.");
			return RedirectToAction("Index");

		}


	}

}
