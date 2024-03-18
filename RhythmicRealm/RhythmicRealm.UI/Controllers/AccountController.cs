using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RhythmicRealm.Entity.Concrete.Identity;
using RhythmicRealm.Shared.ViewModels.Identity;
using RhythmicRealm.UI.EmailServices.Abstract;
using System.Web.Helpers;

namespace RhythmicRealm.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly INotyfService _notyfService;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
		public AccountController(UserManager<User> userManager, INotyfService notyfService, SignInManager<User> signInManager, IEmailSender emailSender)
		{
			_userManager = userManager;
			_notyfService = notyfService;
			_signInManager = signInManager;
			_emailSender = emailSender;
		}

		[HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel,bool memberShipTerms)
        {
            if (ModelState.IsValid && memberShipTerms==true)
            {
                var userName = registerViewModel.Email.Split('@')[0];
                var user = new User
                {
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    Email = registerViewModel.Email,
                    EmailConfirmed = true,
                    Statu=true,
                    UserName = userName,
                    

                };
                var result= await _userManager.CreateAsync(user, registerViewModel.Password);
                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        _notyfService.Error(item.Description);
                    }
                }

				//var tokenCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);
				//var backUrl = Url.Action("ConfirmEmail", "Account", new
				//{
				//    userId = user.Id,
				//    token = tokenCode
				//});

				//await _emailSender.SendEmailAsync(
				//    user.Email,
				//    "Rhythmic Realm App Üyelik Onayı",
				//    $"<p>Rhythmic Realm sitesine üyeliğinizi onaylamak için aşağıdaki linke tıklayınız.</p><a href='http://localhost:5066{backUrl}'>ONAY LİNKİ</a>"
				//    );

				//await _shoppingCartManager.InitializeShoppingCartAsync(userId);
				await _userManager.AddToRoleAsync(user, "Customer");
                _notyfService.Success("Üyelik kaydınız başarıyla tamamlanmıştır. Lütfen mail adresinize gelen onay linkine tıklayınız.",5);
                return RedirectToAction("Login");
                
            }
            return View(registerViewModel);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
			if (userId == null || token == null)
			{
				_notyfService.Warning("Bilgilerinizde hata var. Kontrol ediniz.");
				return View();
			}
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
			{
				_notyfService.Error("Kullanıcı bilgilerinize ulaşılamadı.");
				return View();
			}
			var result = await _userManager.ConfirmEmailAsync(user, token);
			if (result.Succeeded)
			{
				//await _shoppingCartManager.InitializeShoppingCartAsync(userId);
				_notyfService.Information("Hesabınız başarıyla onaylanmıştır.");
				return RedirectToAction("Login");
			}
			_notyfService.Error("Hesabınız onaylanırken bir sorun oluştu, daha sonra tekrar deneyiniz.");
			return View();
		}


        [HttpGet]
        public  IActionResult Login(string returnUrl = null)
        {
            if (returnUrl != null)
            {
                TempData["ReturnUrl"] = returnUrl;
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    //İlgili kullanıcıya dair önceden oluşturulmuş bir Cookie varsa siliyoruz.
                    await _signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password,false,true);

                    if (result.Succeeded)
                    {
                        await _userManager.ResetAccessFailedCountAsync(user); //Önceki hataları girişler neticesinde +1 arttırılmış tüm değerleri 0(sıfır)a çekiyoruz.

                        if (string.IsNullOrEmpty(TempData["returnUrl"] != null ? TempData["returnUrl"].ToString() : ""))
                            return Redirect("~/");
                        return Redirect(TempData["returnUrl"].ToString());
                    }
                    else
                    {
                     
                        int failcount = await _userManager.GetAccessFailedCountAsync(user); //Kullanıcının yapmış olduğu başarısız giriş deneme adedini alıyoruz.
                        if (failcount == 3)
                        {
                            await _userManager.SetLockoutEndDateAsync(user, new DateTimeOffset(DateTime.Now.AddMinutes(1))); //Eğer ki başarısız giriş denemesi 3'ü bulduysa ilgili kullanıcının hesabını kilitliyoruz.
                            ModelState.AddModelError("", "Art arda 3 başarısız giriş denemesi yaptığınızdan dolayı hesabınız 1 dk kitlenmiştir.");
                        }
                        else
                        {
                            if (result.IsLockedOut)
                                ModelState.AddModelError("", "Art arda 3 başarısız giriş denemesi yaptığınızdan dolayı hesabınız 1 dk kilitlenmiştir.");
                            else
                                ModelState.AddModelError("", "E-posta veya şifre yanlış.");
                        }

                    }
                }
                else
                {
                    ModelState.AddModelError("", "Böyle bir kullanıcı bulunmamaktadır.");
                    ModelState.AddModelError("", "E-posta veya şifre yanlış.");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel)
        {
			if (forgotPasswordViewModel.Email == null)
			{
				ModelState.AddModelError("", "Mail adresinizi yazınız.");
				return View();
			}
			var user = await _userManager.FindByEmailAsync(forgotPasswordViewModel.Email);
			if (user == null)
			{
				ModelState.AddModelError("", "Böyle bir hesap bulunamadı.");
				return View();
			}
			var tokenCode = await _userManager.GeneratePasswordResetTokenAsync(user);
			var backUrl = Url.Action("ResetPassword", "Account", new
			{
				userId = user.Id,
				tokenCode = tokenCode
			});
			var subject = "RhythmicRealm Şifre Sıfırlama";
			var htmlMessage = $"<h1> Şifre Sıfırlama İşlemi</h1>" +
				$"<p>" +
				$"Lütfen şifrenizi sıfırlamak için aşağıdaki linke tıklayınız." +
				$"</p>" +
				$"<a href='http://localhost:5066{backUrl}'>Şifre Sıfırla</a>";
			await _emailSender.SendEmailAsync(forgotPasswordViewModel.Email, subject, htmlMessage);
			return RedirectToAction("Login");
		}

		public async Task<IActionResult> ResetPassword(string userId, string tokenCode)
		{
			if (userId == null || tokenCode == null)
			{
				ModelState.AddModelError("", "Bir sorun oluştu");
				return View();
			}
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
			{
				ModelState.AddModelError("", "Böyle bir kullanıcı bulunamadı");
				return View();
			}
			ResetPasswordViewModel resetPasswordViewModel = new ResetPasswordViewModel
			{
				UserId = userId,
				TokenCode = tokenCode
			};
			return View(resetPasswordViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			var user = await _userManager.FindByIdAsync(resetPasswordViewModel.UserId);
			if (user == null)
			{
				ModelState.AddModelError("", "Böyle bir kullanıcı bulunamadı");
				return View(resetPasswordViewModel);
			}
			var result = await _userManager.ResetPasswordAsync(
				user,
				resetPasswordViewModel.TokenCode,
				resetPasswordViewModel.Password);
			if (result.Succeeded)
			{
				return RedirectToAction("Login");
			}
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError("", error.Description);
			}
			return View(resetPasswordViewModel);
		}


		public IActionResult ChangePassword()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdatePassword(UpdatePasswordViewModel updatePasswordViewModel)
		{
			return View();
		}

		public async Task<IActionResult> AccessDenied()
		{
			return View();
		}

	}

    
}
