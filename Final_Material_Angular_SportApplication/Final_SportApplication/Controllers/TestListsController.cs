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
    public class TestListsController : Controller
    {
        private IUnitOfWork unitOfWork;
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public TestListsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("Index")]
        public List<TestListModel> Index()
        {
            string userId = null;
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == "UserId"))
            {
                userId = currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            }

            var query = unitOfWork.SportsService.GetTestListsByUserId(userId).ToList();
            foreach (var item in query)
            {
                unitOfWork.SportsService.GetparticpantCount(item.Id);
                unitOfWork.commit();
            }
            return query;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(TestListModel newTestList)
        {
            
            string userId = null;
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == "UserId"))
            {
                userId = currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            }
            newTestList.CoachId = userId;
            var query = unitOfWork.SportsService.GetAllTestLists().ToList();
            if (ModelState.IsValid)
            {
                foreach (var item in query)
                {
                    if (item.TestType == newTestList.TestType)
                    {
                        if (item.Date == newTestList.Date)
                        {
                            return BadRequest();
                        }
                    }
                }
                unitOfWork.SportsService.addTestList(newTestList);
                unitOfWork.commit();
                return Ok(new { message = "Test Created" });
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                unitOfWork.SportsService.deleteTestAthleteData(id);
                unitOfWork.SportsService.deleteTestList(id);
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