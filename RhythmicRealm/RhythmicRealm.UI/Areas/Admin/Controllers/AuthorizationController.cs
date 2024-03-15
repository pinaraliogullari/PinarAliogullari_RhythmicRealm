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
                    Role = userRole 
                };

                usersWithRoles.Add(userWithRoles);

            }

            return View(usersWithRoles);
        }

        //[Authorize("SuperAdmin")]
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
    }
}
