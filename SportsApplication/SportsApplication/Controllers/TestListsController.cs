using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsApplication.Data;
using SportsApplication.Data.Entity;

namespace SportsApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestListsController : Controller
    {
        private readonly ISportsService sportsService;
      
        private readonly DataDbContext _context;

        public TestListsController(DataDbContext context, ISportsService sportsService)
        {
            _context = context;
            this.sportsService = sportsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var query = sportsService.GetAllTestLists().ToList();
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
        public IActionResult Create(TestList testList)
        {
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
    }
}
