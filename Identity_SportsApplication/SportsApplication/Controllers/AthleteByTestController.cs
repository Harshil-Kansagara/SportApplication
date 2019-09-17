using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportsApplication.Data;
using SportsApplication.Data.Entity;

namespace SportsApplication.Controllers
{
    public class AthleteByTestController : Controller
    {
        private ISportsService sportsService;
        private DataDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public AthleteByTestController(ISportsService sportsService, DataDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.sportsService = sportsService;
            this.context = context;
            this.userManager = userManager;
        }

        public IActionResult Index(int id)
        {
            var testmodel = sportsService.GetTestDetail(id);
            GetAthleteDataModel model = new GetAthleteDataModel();
            model.TestId = id;
            model.date = testmodel.date;
            model.test_type = testmodel.test_type;
            model.AthleteList = sportsService.GetAthleteList(id);
            model.allAthleteLists = sportsService.GetAllAthlete().ToList();
            
            return View(model);
        }

        public async Task<IActionResult> Create(int id)
        {
            var currentUser = await userManager.GetUserAsync(HttpContext.User);
            var userId = currentUser.Id;
            var model = new AddAthleteModel();
            model.testId = id;
            model.athleteList= sportsService.GetAthleteByUserId(userId).ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddAthleteModel addAthleteModel)
        {
            var currentUser = await userManager.GetUserAsync(HttpContext.User);
            var userId = currentUser.Id;
            var query = sportsService.GetAthleteList(addAthleteModel.testId);
            if (ModelState.IsValid)
            {
                foreach (var item in query)
                {
                    if (item.athlete_id == addAthleteModel.athlete_id)
                    {
                        ViewBag.message = "Athlete with same name already exists in this test. Please delete first!";
                        var mod = new AddAthleteModel();
                        mod.testId = addAthleteModel.testId;
                        mod.athleteList = sportsService.GetAllAthlete().ToList();
                        return View(mod);
                    }
                }
               sportsService.addAthleteByTest(new AthleteByTest() { test_id = addAthleteModel.testId, athlete_id = addAthleteModel.athlete_id, athlete_distance = addAthleteModel.distance });
               sportsService.commit();
               return RedirectToAction(nameof(Index), new { id = addAthleteModel.testId });
                
            }
            var model = new AddAthleteModel();
            model.testId = addAthleteModel.testId;
            model.athleteList = sportsService.GetAthleteByUserId(userId).ToList();
            return View(model);
        }

        public IActionResult Edit(int athleteId, int testId)
        {
            var model = new EditAthleteDataModel();
            model.TestId = testId;
            model.id = sportsService.GetAthleteTableid(athleteId, testId);
            model.athleteList = sportsService.GetAllAthlete().ToList();
            model.distance = sportsService.GetAthleteDistance(model.id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditAthleteDataModel editAthleteData)
        {
            if (ModelState.IsValid)
            {
                sportsService.updateAthleteData(editAthleteData);
                sportsService.commit();
                return RedirectToAction(nameof(Index), new { id = editAthleteData.TestId});
            }
            return View(editAthleteData);
        }

        public IActionResult Delete(int id, int testId)
        {
            Console.WriteLine(id+ "##################"+testId);
            var model = new DeleteAthleteDataModel();
            model.id = id;
            model.testId = testId;
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(DeleteAthleteDataModel deleteAthlete)
        {
            sportsService.deleteAthleteData(deleteAthlete.id);
            sportsService.commit();
            return RedirectToAction(nameof(Index),new { id = deleteAthlete.testId});
        }
    }
}