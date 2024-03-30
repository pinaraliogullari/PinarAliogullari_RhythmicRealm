using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RhythmicRealm.Entity.Concrete.Identity;
using RhythmicRealm.Shared.ViewModels.Identity;

namespace RhythmicRealm.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class AuthorizationController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly INotyfService _notyfService;

        public AuthorizationController(UserManager<User> userManager, RoleManager<Role> roleManager, INotyfService notyfService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _notyfService = notyfService;
        }

        public async Task<IActionResult> Index()
        {
     
            var users = await _userManager.Users.ToListAsync();

            var usersWithRoles = new List<UserListViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var userRole = roles.FirstOrDefault(); 

                var userWithRoles = new UserListViewModel
                {
                    Id = user.Id,
                    FullName = $"{user.FirstName} {user.LastName}",
                    UserName = user.UserName,
                    Email = user.Email,
                    Role = userRole,
                    Statu =user.Statu
                };

                usersWithRoles.Add(userWithRoles);

            }

            return View(usersWithRoles);
        }


        [Authorize(Roles ="SuperAdmin")]   
        [HttpGet]
        public async Task<IActionResult> ChangeAuthority(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roles = await _userManager.GetRolesAsync(user);

            var model = new ChangeAuthorityViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                FullName = $"{user.FirstName} {user.LastName}",
                AssignRole = _roleManager.Roles.Select(r => new AssignRoleViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    IsAssigned = roles.Contains(r.Name) 
                }).ToList()
            };

            return View(model);
        }

		[HttpPost]
        public async Task<IActionResult> ChangeAuthority(ChangeAuthorityViewModel changeAuthorityViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(changeAuthorityViewModel.Id);
                foreach (var roleViewModel in changeAuthorityViewModel.AssignRole)
                {
                    var role = await _roleManager.FindByIdAsync(roleViewModel.Id);

                    if (role == null)
                    {
                        ModelState.AddModelError("", $"Rol ID'si {roleViewModel.Id} olan rol bulunamadı.");
                        return View(changeAuthorityViewModel);
                    }

                    var isInRole = await _userManager.IsInRoleAsync(user, role.Name);
                    if (roleViewModel.IsAssigned && !isInRole)
                    {
                        await _userManager.AddToRoleAsync(user, role.Name);
                    }
                    else if (!roleViewModel.IsAssigned && isInRole)
                    {
                        await _userManager.RemoveFromRoleAsync(user, role.Name);
                    }
                }
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(changeAuthorityViewModel);
                }

                _notyfService.Success($"{user.FirstName} {user.LastName} adlı kullanıcının rolü başarıyla güncellendi.");
                return RedirectToAction("Index");
            }

            _notyfService.Error("Güncelleme işlemi başarısız oldu.");
            return View(changeAuthorityViewModel);
        }


        public async Task<IActionResult> ChangeStatu(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                if (await _userManager.IsLockedOutAsync(user))
                {
                    await _userManager.SetLockoutEndDateAsync(user, null);
                }
                if (user.Statu)
                {
                    await _userManager.SetLockoutEnabledAsync(user, true);
                    await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MaxValue);
                    user.Statu = false;
                }
                else
                {
                    await _userManager.SetLockoutEnabledAsync(user, false);
                    await _userManager.SetLockoutEndDateAsync(user, null);
                    user.Statu = true;
                }
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index");
            }

       
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ViewPersons(string statu)
        {
            if (statu == "Customers")
            {
                var users = _userManager.Users
                    .Where(u => u.RoleId == "91e997e8-ac8c-4196-95ea-114d5e158d77").ToList();

                return View(users);
            }
            else if (statu == "Admins")
            {
                var users = _userManager.Users
                    .Where(u => u.RoleId == "27d33046-bbb2-477a-bcb5-ee4e9f87862e" || u.RoleId== "4986ce01-879d-49c7-95d4-a13610cd153b").ToList();
                return View(users);
            }
            return View();
        }

    }
}
