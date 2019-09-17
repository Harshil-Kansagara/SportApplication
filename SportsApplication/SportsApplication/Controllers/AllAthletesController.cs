using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsApplication.Data;
using SportsApplication.Data.Entity;

namespace SportsApplication.Controllers
{
    public class AllAthletesController : Controller
    {
        private readonly ISportsService sportsService;
        private readonly DataDbContext context;

        public AllAthletesController(ISportsService sportsService, DataDbContext context)
        {
            this.sportsService = sportsService;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(sportsService.GetAllAthlete().ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AllAthleteList allAthleteList)
        {
            var query = sportsService.GetAllAthlete().ToList();
            if (ModelState.IsValid)
            {
                foreach (var item in query)
                {
                    if(item.athlete_name == allAthleteList.athlete_name)
                    {
                        ViewBag.message = "Athlete already exists";
                        return View();
                    }
                }
                sportsService.addAthlete(allAthleteList);
                sportsService.commit();
                return RedirectToAction(nameof(Index));
            }
            return View(allAthleteList);
        }

        public IActionResult Delete(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }

            var athleteList = sportsService.GetAthleteName(id).FirstOrDefault();
            if(athleteList == null)
            {
                return NotFound();
            }
            return View(athleteList);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            sportsService.deleteAthlete(id);
            sportsService.deleteAthleteFromTest(id);
            sportsService.commit();
            return RedirectToAction(nameof(Index));
        }
    }
}