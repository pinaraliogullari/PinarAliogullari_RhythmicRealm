using Microsoft.AspNetCore.Mvc;
using RhythmicRealm.Service.Abstract;
using RhythmicRealm.Service.Concrete;

namespace RhythmicRealm.UI.Areas.Admin.Controllers
{

	//şu an için bu controllerı kullanmıyorum
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
			var contactValues= await _contactService.GetMessagesListInInboxAsync();
			return View(contactValues.Data);
		}

        public async Task<IActionResult> GetContactDetails(int id)
        {
            var contactValues = await _contactService.GetMessageAsync(id);
            return View(contactValues.Data);
        }
    }
}
