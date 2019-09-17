using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsApplication.Data;
using SportsApplication.Data.Entity;

namespace SportsApplication.Controllers
{
    public class TestListsController : Controller
    {
        private readonly ISportsService sportsService;
      
        private readonly DataDbContext _context;

        private readonly UserManager<ApplicationUser> userManager;

        public TestListsController(DataDbContext context, ISportsService sportsService, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.sportsService = sportsService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await userManager.GetUserAsync(HttpContext.User);
            var userId = currentUser.Id;
            var query = sportsService.GetTestListsByUserId(userId).ToList();
            foreach (var item in query)
            {
                sportsService.GetparticpantCount(item.id);
                sportsService.commit();
            }
            return View(query);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TestList testList)
        {
            var currentUser = await userManager.GetUserAsync(HttpContext.User);
            var userId = currentUser.Id;
            testList.coachId = userId;
            var query = sportsService.GetAllTestLists().ToList();
            if (ModelState.IsValid)
            {
                foreach (var item in query)
                {
                    if (item.test_type == testList.test_type)
                    { 
                        if (item.date == testList.date)
                        {
                            ViewBag.message = "The test type with same date is already added. Please delete first!";
                            return View();
                        }
                    }    
                }
                sportsService.addTestList(testList);
                sportsService.commit();
                return RedirectToAction(nameof(Index));
            }
            return View(testList);
        }

        public IActionResult Delete(int id)
        {
            var testList = sportsService.GetTestListData(id).FirstOrDefault(); 
            if (testList == null)
            {
                return NotFound();
            }

            return View(testList);
        }
        
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            sportsService.deleteTestAthleteData(id);
            sportsService.deleteTestList(id);
            sportsService.commit();
            return RedirectToAction(nameof(Index));
        }

        //private Task<ApplicationUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);
    }
}
