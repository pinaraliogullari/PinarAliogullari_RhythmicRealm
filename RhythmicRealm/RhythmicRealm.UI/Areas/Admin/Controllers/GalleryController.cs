using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Service.Abstract;

namespace RhythmicRealm.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class GalleryController : Controller
	{
		private readonly IImageFileService _imageFileService;

        public GalleryController(IImageFileService imageFileService)
        {
            _imageFileService = imageFileService;
        }

        public async Task<IActionResult> Index()
		{
			var photos = await _imageFileService.GetAllAsync();
			return View(photos.Data);
		}
	}
}
