using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportsApplication.Data;
using SportsApplication.Data.Entity;

namespace SportsApplication.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly ISportsService sportsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
       private readonly RoleManager<IdentityRole> roleManager;


        public AccountController(ISportsService sportsService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, 
            RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
            this.sportsService = sportsService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            var roleList = roleManager.Roles.ToList();
            var model = new RegisterViewModel();
            foreach (var item in roleList)
            {
                model.roleViewList.Add(item);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel newRegisterViewModel)
        {
            var roleList = roleManager.Roles.ToList();
            var model = new RegisterViewModel();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = newRegisterViewModel.Name,
                    Email = newRegisterViewModel.Email,
                    RoleId = newRegisterViewModel.RoleId
                };

                var result = await userManager.CreateAsync(user, newRegisterViewModel.Password);

                if(result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    if (newRegisterViewModel.RoleId == "d6272412-958c-472d-91d1-d0afd48e7452")
                        return RedirectToAction("Index", "TestLists");
                    else if (newRegisterViewModel.RoleId == "36bf775a-621e-4a6d-92b5-5263da58882c")
                        return RedirectToAction("Index", "AthleteDetails");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            foreach (var item in roleList)
            {
                model.roleViewList.Add(item);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            if(User.Identity.IsAuthenticated)
            { 
            var currentUser = await userManager.GetUserAsync(HttpContext.User);
            var user = await userManager.FindByIdAsync(currentUser.Id);

            if (user.RoleId == "d6272412-958c-472d-91d1-d0afd48e7452")
            {
                return RedirectToAction("Index", "TestLists");
            }
            else if(user.RoleId == "36bf775a-621e-4a6d-92b5-5263da58882c")
            {
                return RedirectToAction("Index", "AthleteDetails");
            }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginView)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginView.Name, loginView.Password, loginView.RememberMe, false);
                var user = await userManager.FindByNameAsync(loginView.Name);
                
                if (result.Succeeded)
                {
                    if (user.RoleId == "d6272412-958c-472d-91d1-d0afd48e7452")
                        return RedirectToAction("Index", "TestLists");
                    else if (user.RoleId == "36bf775a-621e-4a6d-92b5-5263da58882c")
                        return RedirectToAction("Index", "AthleteDetails"); 
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(loginView);
        }
    }
}