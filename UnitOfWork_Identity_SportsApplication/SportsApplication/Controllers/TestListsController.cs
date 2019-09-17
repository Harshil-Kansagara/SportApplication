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
    public class TestListsController : Controller
    {
        private IUnitOfWork unitOfWork;

        public TestListsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ClaimsPrincipal r = HttpContext.User;
            var currentUser = await unitOfWork.SportsService.GetCurrentUser(r);
            var userId = currentUser.Id;
            var query = unitOfWork.SportsService.GetTestListsByUserId(userId).ToList();
            foreach (var item in query)
            {
                unitOfWork.SportsService.GetparticpantCount(item.id);
                unitOfWork.commit();
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
            ClaimsPrincipal r = HttpContext.User;
            var currentUser = await unitOfWork.SportsService.GetCurrentUser(r);
            var userId = currentUser.Id;
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
                            ViewBag.message = "The test type with same date is already added. Please delete first!";
                            return View();
                        }
                    }    
                }
                unitOfWork.SportsService.addTestList(testList);
                unitOfWork.commit();
                return RedirectToAction(nameof(Index));
            }
            return View(testList);
        }

        public IActionResult Delete(int id)
        {
            var testList = unitOfWork.SportsService.GetTestListData(id).FirstOrDefault(); 
            if (testList == null)
            {
                return NotFound();
            }

            return View(testList);
        }
        
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            unitOfWork.SportsService.deleteTestAthleteData(id);
            unitOfWork.SportsService.deleteTestList(id);
            unitOfWork.commit();
            return RedirectToAction(nameof(Index));
        }
    }
}
