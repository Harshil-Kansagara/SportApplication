using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SportsApplication.Data;
using SportsApplication.Data.Entity;

namespace SportsApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private IUnitOfWork unitOfWork;
        private UserManager<ApplicationUser> userManager;
        private readonly ApplicationSettings _appSettings;

        public AccountController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IOptions<ApplicationSettings> appSettings)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        [Route("Register")]
        //GET: api/Account/Register
        public List<IdentityRole> Register()
        {
            var roleList = unitOfWork.SportsService.getAllRoles();
            //var model = new RegisterViewModel();
            //foreach (var item in roleList)
            //{
            //    model.roleViewList.Add(item);
            //}
            return roleList;
        }

        [HttpPost]
        [Route("Register")]
        //POST: /api/Account/Register
        public async Task<Object> Register(RegisterViewModel newRegisterViewModel)
        {
            var roleList = unitOfWork.SportsService.getAllRoles();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = newRegisterViewModel.Name,
                    Email = newRegisterViewModel.Email,
                    RoleId = newRegisterViewModel.RoleId
                };

                
                try {
                    var result = await unitOfWork.SportsService.registerUser(user, newRegisterViewModel.Password);
                    //unitOfWork.SportsService.signInUser(user);
                    return Ok(result);
                }catch(Exception ex)
                {
                    throw ex;
                }
            }
           
            return roleList;
        }

        [HttpPost]
        [Route("LogOut")]
        //GET: api/Account/LogOut
        public IActionResult Logout()
        {
            unitOfWork.SportsService.logout();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        [Route("Login")]
        //GET: api/Account/Login
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
        [Route("Login")]
        //POST: api/Account/Login
        public async Task<IActionResult> Login(LoginViewModel loginView)
        {
            if (ModelState.IsValid)
            {
                var result = await unitOfWork.SportsService.login(loginView);
                var user = await unitOfWork.SportsService.GetCurrentUserDetail(loginView.Name);
                var claims = new List<Claim> {
                             new Claim("UserId", user.Id.ToString()),
                              new Claim("UserName", user.UserName.ToString()),
                              new Claim("UserRoleId", user.RoleId.ToString())
                };
                if (result.Succeeded)
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);
                    var tokenOptions = new JwtSecurityToken
                    (
                        issuer:"http://localhost/5001",
                        audience: "http://localhost/5001",
                        claims: claims,
                        expires: DateTime.Now.AddDays(1),
                        signingCredentials: signinCredentials
                    );
                    var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    return Ok(new { token });
                }
                else
                {
                    return BadRequest(new { message = "Username or password is incorrect." });
                }
            }
            return View();
        }
    }
}