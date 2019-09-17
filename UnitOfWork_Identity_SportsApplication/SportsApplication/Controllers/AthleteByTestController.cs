using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private IUnitOfWork unitOfWork;

        public AthleteByTestController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index(int id)
        {
            var testmodel = unitOfWork.SportsService.GetTestDetail(id);
            GetAthleteDataModel model = new GetAthleteDataModel();
            model.TestId = id;
            model.date = testmodel.date;
            model.test_type = testmodel.test_type;
            model.AthleteList = unitOfWork.SportsService.GetAthleteList(id);
            model.allAthleteLists = unitOfWork.SportsService.GetAllAthlete().ToList();
            
            return View(model);
        }

        public async Task<IActionResult> Create(int id)
        {
            ClaimsPrincipal r = HttpContext.User;
            var currentUser = await unitOfWork.SportsService.GetCurrentUser(r);
            var userId = currentUser.Id;
            var model = new AddAthleteModel();
            model.testId = id;
            model.athleteList= unitOfWork.SportsService.GetAthleteByUserId(userId).ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddAthleteModel addAthleteModel)
        {
            ClaimsPrincipal r = HttpContext.User;
            var currentUser = await unitOfWork.SportsService.GetCurrentUser(r);
            var userId = currentUser.Id;
            var query = unitOfWork.SportsService.GetAthleteList(addAthleteModel.testId);
            if (ModelState.IsValid)
            {
                foreach (var item in query)
                {
                    if (item.athlete_id == addAthleteModel.athlete_id)
                    {
                        ViewBag.message = "Athlete with same name already exists in this test. Please delete first!";
                        var mod = new AddAthleteModel();
                        mod.testId = addAthleteModel.testId;
                        mod.athleteList = unitOfWork.SportsService.GetAllAthlete().ToList();
                        return View(mod);
                    }
                }
               unitOfWork.SportsService.addAthleteByTest(new AthleteByTest() { test_id = addAthleteModel.testId, athlete_id = addAthleteModel.athlete_id, athlete_distance = addAthleteModel.distance });
               unitOfWork.commit();
               return RedirectToAction(nameof(Index), new { id = addAthleteModel.testId });
                
            }
            var model = new AddAthleteModel();
            model.testId = addAthleteModel.testId;
            model.athleteList = unitOfWork.SportsService.GetAthleteByUserId(userId).ToList();
            return View(model);
        }

        public async Task<IActionResult> Edit(int athleteId, int testId)
        {
            ClaimsPrincipal r = HttpContext.User;
            var currentUser = await unitOfWork.SportsService.GetCurrentUser(r);
            var userId = currentUser.Id;
            var model = new EditAthleteDataModel();
            model.TestId = testId;
            model.id = unitOfWork.SportsService.GetAthleteTableid(athleteId, testId);
            model.athleteList = unitOfWork.SportsService.GetAthleteByUserId(userId);
            model.distance = unitOfWork.SportsService.GetAthleteDistance(model.id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditAthleteDataModel editAthleteData)
        {
            var query = unitOfWork.SportsService.GetAthleteList(editAthleteData.TestId);
            if (ModelState.IsValid)
            {
                foreach (var item in query)
                {
                    if (item.athlete_id == editAthleteData.athleteId)
                    {
                        ViewBag.message = "Athlete with same name data already exists. Please delete first!";
                        ClaimsPrincipal r = HttpContext.User;
                        var currentUser = await unitOfWork.SportsService.GetCurrentUser(r);
                        var userId = currentUser.Id;
                        var model = new EditAthleteDataModel();
                        model.TestId = editAthleteData.TestId;
                        model.id = unitOfWork.SportsService.GetAthleteTableid(editAthleteData.athleteId, editAthleteData.TestId);
                        model.athleteList = unitOfWork.SportsService.GetAthleteByUserId(userId);
                        model.distance = unitOfWork.SportsService.GetAthleteDistance(model.id);
                        return View(model);
                    }
                }
                unitOfWork.SportsService.updateAthleteData(editAthleteData);
                unitOfWork.commit();
                return RedirectToAction(nameof(Index), new { id = editAthleteData.TestId});
            }
            return View(editAthleteData);
        }

        public IActionResult Delete(int id, int testId)
        {
            var model = new DeleteAthleteDataModel();
            model.id = id;
            model.testId = testId;
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(DeleteAthleteDataModel deleteAthlete)
        {
            unitOfWork.SportsService.deleteAthleteData(deleteAthlete.id);
            unitOfWork.commit();
            return RedirectToAction(nameof(Index),new { id = deleteAthlete.testId});
        }
    }
}