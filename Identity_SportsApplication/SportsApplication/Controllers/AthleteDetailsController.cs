using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportsApplication.Data;
using SportsApplication.Data.Entity;

namespace SportsApplication.Controllers
{
    public class AthleteDetailsController : Controller
    {
        private readonly ISportsService sportsService;
        private readonly UserManager<ApplicationUser> userManager;
        
        public AthleteDetailsController(ISportsService sportsService, UserManager<ApplicationUser> userManager)
        {
            this.sportsService = sportsService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await userManager.GetUserAsync(HttpContext.User);
            var username = currentUser.UserName;
            var athleteId = sportsService.getAthleteId(username);
            var model = new AthleteDetailsModel();
            foreach(var id in athleteId)
            {
                var testlists = (sportsService.GetAthleteTestLists(id.id));
                foreach (var item in testlists)
                {
                    model.athleteByTests.Add(item);
                }
            }
            model.testLists = sportsService.GetAllTestLists().ToList();
            model.coach = userManager.Users.ToList();
            return View(model);
        }
    }
}