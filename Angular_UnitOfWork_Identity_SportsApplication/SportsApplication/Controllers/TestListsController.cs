using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsApplication.Data;
using SportsApplication.Data.Entity;

namespace SportsApplication.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TestListsController : Controller
    {
        private IUnitOfWork unitOfWork;

        public TestListsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("Index")]
        public  List<TestList> Index()
        {
            string userId = null;
            var currentUser = HttpContext.User;
            if(currentUser.HasClaim(c=>c.Type == "UserId"))
            {
                userId = currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            }

            //var currentUser = await unitOfWork.SportsService.GetCurrentUser(r);
            //var userId = currentUser.Id;
            var query = unitOfWork.SportsService.GetTestListsByUserId(userId).ToList();
            foreach (var item in query)
            {
                unitOfWork.SportsService.GetparticpantCount(item.id);
                unitOfWork.commit();
            }
            return query;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(TestList testList)
        {
            string userId = null;
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == "UserId"))
            {
                userId = currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            }
            testList.coachId = userId;
            var query = unitOfWork.SportsService.GetAllTestLists().ToList();
            if (ModelState.IsValid)
            {
                foreach (var item in query)
                {
                    if (item.test_type == testList.test_type)
                    { 
                        if (item.date == testList.date)
                        {
                            return BadRequest();
                        }
                    }    
                }
                unitOfWork.SportsService.addTestList(testList);
                unitOfWork.commit();
                return Ok(new { message = "Test Created"});
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public TestList Delete(int id)
        {
            var testList = unitOfWork.SportsService.GetTestListData(id).FirstOrDefault(); 
            if (testList == null)
            {
                return null;
            }

            return testList;
        }
        
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            try { 
            unitOfWork.SportsService.deleteTestAthleteData(id);
            unitOfWork.SportsService.deleteTestList(id);
            unitOfWork.commit();
            return Ok();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
