using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public AthleteByTestController(ISportsService sportsService, DataDbContext context)
        {
            this.sportsService = sportsService;
            this.context = context;
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

        public IActionResult Create(int id)
        {
            var model = new AddAthleteModel();
            model.testId = id;
            model.athleteList= sportsService.GetAllAthlete().ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(AddAthleteModel model)
        {
            var query = sportsService.GetAthleteList(model.testId);
            if (ModelState.IsValid)
            {
                foreach (var item in query)
                {
                    if (item.athlete_id == model.athlete_id)
                    {
                        ViewBag.message = "Athlete with same name already exists in this test. Please delete first!";
                        var mod = new AddAthleteModel();
                        mod.testId = model.testId;
                        mod.athleteList = sportsService.GetAllAthlete().ToList();
                        return View(mod);
                    }
                }
                sportsService.addAthleteByTest(new AthleteByTest() { test_id = model.testId, athlete_id = model.athlete_id, athlete_distance = model.distance });
               sportsService.commit();
               return RedirectToAction(nameof(Index), new { id = model.testId });
                
            }
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