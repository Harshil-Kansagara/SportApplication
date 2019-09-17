using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsApplication.Data;
using SportsApplication.Data.Entity;

namespace SportsApplication.Controllers
{
    public class AllAthletesController : Controller
    {
        private IUnitOfWork unitOfWork;

        public AllAthletesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ClaimsPrincipal r = HttpContext.User; 
            var currentUser = await unitOfWork.SportsService.GetCurrentUser(r);
            var userId = currentUser.Id;
            return View(unitOfWork.SportsService.GetAthleteByUserId(userId));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AllAthleteList allAthleteList)
        {
            ClaimsPrincipal r = HttpContext.User;
            var currentUser = await unitOfWork.SportsService.GetCurrentUser(r);
            var userId = currentUser.Id;
            allAthleteList.coachId = userId;
            var query = unitOfWork.SportsService.GetAllAthlete().ToList();
            if (ModelState.IsValid)
            {
                foreach (var item in query)
                {
                    if(item.athlete_name == allAthleteList.athlete_name && item.coachId == userId)
                    {
                        ViewBag.message = "Athlete already exists";
                        return View();
                    }
                }
                unitOfWork.SportsService.addAthlete(allAthleteList);
                unitOfWork.commit();
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

            var athleteList = unitOfWork.SportsService.GetAthleteName(id).FirstOrDefault();
            if(athleteList == null)
            {
                return NotFound();
            }
            return View(athleteList);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            unitOfWork.SportsService.deleteAthlete(id);
            unitOfWork.SportsService.deleteAthleteFromTest(id);
            unitOfWork.commit();
            return RedirectToAction(nameof(Index));
        }
    }
}