using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_SportApplication.Data;
using Final_SportApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_SportApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AthleteByTestController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public AthleteByTestController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("Index/{id}")]
        public TestDetailModel Index(int id)
        {
            var testmodel = unitOfWork.SportsService.GetTestDetail(id);
            TestDetailModel model = new TestDetailModel();
            model.TestId = id;
            model.Date = testmodel.Date;
            model.TestType = testmodel.TestType;
            model.AthleteList = unitOfWork.SportsService.GetAthleteList(id);
            model.AllAthleteLists = unitOfWork.SportsService.GetAllAthlete().ToList();

            return model;
        }

        [HttpGet]
        [Route("create/{id}")]
        public AddAthleteModel Create(int id)
        {
            string userId = null;
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == "UserId"))
            {
                userId = currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            }
            var model = new AddAthleteModel();
            model.TestId = id;
            model.athleteList = unitOfWork.SportsService.GetAthleteByUserId(userId).ToList();
            return model;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(AddAthleteModel newAthlete)
        {
            var query = unitOfWork.SportsService.GetAthleteList(newAthlete.TestId);
            if (ModelState.IsValid)
            {
                foreach (var item in query)
                {
                    if (item.AthleteId == newAthlete.AthleteId)
                    {
                        return BadRequest();
                    }
                }
                unitOfWork.SportsService.addAthleteByTest(new AthleteByTestModel() { TestId = newAthlete.TestId, AthleteId = newAthlete.AthleteId, AthleteDistance = newAthlete.Distance });
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
            if (currentUser.HasClaim(c => c.Type == "UserId"))
            {
                userId = currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            }
            var model = new EditAthleteDataModel();
            model.TestId = testId;
            model.Id = unitOfWork.SportsService.GetAthleteTableid(athleteId, testId);
            model.AthleteList = unitOfWork.SportsService.GetAthleteByUserId(userId);
            model.Distance = unitOfWork.SportsService.GetAthleteDistance(model.Id);
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

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                unitOfWork.SportsService.deleteAthleteData(id);
                unitOfWork.commit();
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}