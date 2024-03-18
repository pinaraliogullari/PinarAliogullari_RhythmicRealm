using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RhythmicRealm.Entity.Concrete.Identity;
using RhythmicRealm.Shared.ViewModels.Identity;

namespace RhythmicRealm.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly INotyfService _notyfService;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, INotyfService notyfService, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _notyfService = notyfService;
            _signInManager = signInManager;
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
                await _userManager.AddToRoleAsync(user, "Customer");
                _notyfService.Success("Üyelik kaydınız başarıyla tamamlanmıştır. Lütfen mail adresinize gelen onay linkine tıklayınız.",5);
                return RedirectToAction("Login");
                
            }
            return View(registerViewModel);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            if (returnUrl != null)
            {
                TempData["ReturnUrl"] = returnUrl;
            }
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
				if (user != null)
				{
					
					await _signInManager.SignOutAsync();
					var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false,false);

					if (result.Succeeded)
					{
						await _userManager.ResetAccessFailedCountAsync(user);
						_notyfService.Success("Hesabınıza başarıyla giriş yaptınız.");
						if (string.IsNullOrEmpty(TempData["returnUrl"] != null ? TempData["returnUrl"].ToString() : ""))
						return Redirect("~/");
						return Redirect(TempData["returnUrl"].ToString());
						
					}
					else
					{
						await _userManager.AccessFailedAsync(user); 

						int failcount = await _userManager.GetAccessFailedCountAsync(user); 
						if (failcount == 3)
						{
							await _userManager.SetLockoutEndDateAsync(user, new DateTimeOffset(DateTime.Now.AddMinutes(1))); 
							ModelState.AddModelError("Locked", "Art arda 3 başarısız giriş denemesi yaptığınızdan dolayı hesabınız 1 dk kitlenmiştir.");
						}
						else
						{
							if (result.IsLockedOut)
								ModelState.AddModelError("Locked", "Art arda 3 başarısız giriş denemesi yaptığınızdan dolayı hesabınız 1 dk kilitlenmiştir.");
							else
								ModelState.AddModelError("NotUser2", "E-posta veya şifre yanlış.");
						}

					}
				}
				else
				{
					ModelState.AddModelError("NotUser", "Böyle bir kullanıcı bulunmamaktadır.");
					ModelState.AddModelError("NotUser2", "E-posta veya şifre yanlış.");
				}
			}
            
			return View(loginViewModel);
		}
	


	    public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }
        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            return View();
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


    }
}
