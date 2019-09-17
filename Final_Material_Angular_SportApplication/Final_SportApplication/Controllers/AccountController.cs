using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Final_SportApplication.Data;
using Final_SportApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Final_SportApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        private UserManager<ApplicationUser> userManager;
        private readonly ApplicationSettingModel _appSettings;

        public AccountController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IOptions<ApplicationSettingModel> appSettings)
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
            return roleList;
        }

        [HttpPost]
        [Route("Register")]
        //POST: /api/Account/Register
        public async Task<Object> Register(RegisterModel newRegisterUser)
        {
            var roleList = unitOfWork.SportsService.getAllRoles();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = newRegisterUser.Name,
                    Email = newRegisterUser.Email,
                    RoleId = newRegisterUser.RoleId
                };


                try
                {
                    var result = await unitOfWork.SportsService.registerUser(user, newRegisterUser.Password);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return roleList;
        }

        [HttpPost]
        [Route("Login")]
        //POST: api/Account/Login
        public async Task<IActionResult> Login(LoginModel loginUser)
        {
            if (ModelState.IsValid)
            {
                var result = await unitOfWork.SportsService.login(loginUser);
                var user = await unitOfWork.SportsService.GetCurrentUserDetail(loginUser.Name);
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
                        issuer: "http://localhost/5001",
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
            return BadRequest();
        }
    }
}