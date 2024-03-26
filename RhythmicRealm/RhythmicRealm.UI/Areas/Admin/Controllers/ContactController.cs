using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Service.Abstract;

namespace RhythmicRealm.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ContactController : Controller
	{
		private readonly IContactService _contactService;

		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}

		public async Task<IActionResult> Index()
		{
			var contactValues= await _contactService.GetMessagesListAsync();
			return View(contactValues.Data);
		}

        public async Task<IActionResult> GetContactDetails(int id)
        {
            var contactValues = await _contactService.GetMessageAsync(id);
            return View(contactValues.Data);
        }
    }
}
