using System.Security.Claims;
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
        private IUnitOfWork unitOfWork;
        private UserManager<ApplicationUser> userManager;

        public AccountController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }

        public IActionResult Register()
        {
            var roleList = unitOfWork.SportsService.getAllRoles();
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
            var roleList = unitOfWork.SportsService.getAllRoles();
            var model = new RegisterViewModel();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = newRegisterViewModel.Name,
                    Email = newRegisterViewModel.Email,
                    RoleId = newRegisterViewModel.RoleId
                };

                var result = await unitOfWork.SportsService.registerUser(user, newRegisterViewModel.Password);

                if(result.Succeeded)
                {
                    unitOfWork.SportsService.signInUser(user);
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
        public IActionResult Logout()
        {
            unitOfWork.SportsService.logout();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            if(User.Identity.IsAuthenticated)
            {
                ClaimsPrincipal r = HttpContext.User;
            var currentUser = await unitOfWork.SportsService.GetCurrentUser(r);
                var user = await unitOfWork.SportsService.GetUserById(currentUser.Id);

                if (user.RoleId == "d6272412-958c-472d-91d1-d0afd48e7452")
                {
                    return RedirectToAction("Index", "TestLists");
                }
                else if (user.RoleId == "36bf775a-621e-4a6d-92b5-5263da58882c")
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
                var result = await unitOfWork.SportsService.login(loginView);
                var user = await unitOfWork.SportsService.GetCurrentUserDetail(loginView.Name);
                
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