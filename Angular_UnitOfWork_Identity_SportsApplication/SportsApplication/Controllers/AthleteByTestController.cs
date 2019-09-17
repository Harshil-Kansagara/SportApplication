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
    [Route("api/[controller]")]
    [ApiController]
    public class AthleteByTestController : Controller
    {
        private IUnitOfWork unitOfWork;

        public AthleteByTestController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("Index/{id}")]
        public GetAthleteDataModel Index(int id)
        {
            var testmodel = unitOfWork.SportsService.GetTestDetail(id);
            GetAthleteDataModel model = new GetAthleteDataModel();
            model.TestId = id;
            model.date = testmodel.date;
            model.test_type = testmodel.test_type;
            model.AthleteList = unitOfWork.SportsService.GetAthleteList(id);
            model.allAthleteLists = unitOfWork.SportsService.GetAllAthlete().ToList();
            
            return model;
        }

        [HttpGet]
        [Route("create/{id}")]
        public AddAthleteModel Create(int id)
        {
            string userId = null;
            var currentUser = HttpContext.User;
            if(currentUser.HasClaim(c=>c.Type == "UserId")) { 
                userId = currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            }
            var model = new AddAthleteModel();
            model.testId = id;
            model.athleteList= unitOfWork.SportsService.GetAthleteByUserId(userId).ToList();
            return model;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(AddAthleteModel addAthleteModel)
        {
            var query = unitOfWork.SportsService.GetAthleteList(addAthleteModel.testId);
            if (ModelState.IsValid)
            {
                foreach (var item in query)
                {
                    if (item.athlete_id == addAthleteModel.athlete_id)
                    {
                        return BadRequest();
                    }
                }
               unitOfWork.SportsService.addAthleteByTest(new AthleteByTest() { test_id = addAthleteModel.testId, athlete_id = addAthleteModel.athlete_id, athlete_distance = addAthleteModel.distance });
               unitOfWork.commit();
               return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("edit/{testId}/{athleteId}")]
        public EditAthleteDataModel Edit(int testId, int athleteId)
        {
            string userId = null;
            var currentUser = HttpContext.User;
            if(currentUser.HasClaim(c=>c.Type=="UserId"))
            {
                userId = currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            }
            var model = new EditAthleteDataModel();
            model.TestId = testId;
            model.id = unitOfWork.SportsService.GetAthleteTableid(athleteId, testId);
            model.athleteList = unitOfWork.SportsService.GetAthleteByUserId(userId);
            model.distance = unitOfWork.SportsService.GetAthleteDistance(model.id);
            return model;
        }

        [HttpPost]
        [Route("edit")]
        public IActionResult Edit(EditAthleteDataModel editAthleteData)
        {
            var query = unitOfWork.SportsService.GetAthleteList(editAthleteData.TestId);
            if (ModelState.IsValid)
            {
                //foreach (var item in query)
                //{
                //    if (item.athlete_id == editAthleteData.athleteId)
                //    {
                        
                //        return BadRequest();
                //    }
                //}
                unitOfWork.SportsService.updateAthleteData(editAthleteData);
                unitOfWork.commit();
                return Ok();
            }
            return BadRequest();
        }

        public IActionResult Delete(int id, int testId)
        {
            var model = new DeleteAthleteDataModel();
            model.id = id;
            model.testId = testId;
            return View(model);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            try { 
            unitOfWork.SportsService.deleteAthleteData(id);
            unitOfWork.commit();
            return Ok();
            } catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}