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
    [Route("api/[Controller]")]
    [ApiController]
    public class AllAthletesController : Controller
    {
        private IUnitOfWork unitOfWork;

        public AllAthletesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("Index")]
        public List<AllAthleteList> Index()
        {
            string userId = null;
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == "UserId"))
            {
                userId = currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            }
            return unitOfWork.SportsService.GetAthleteByUserId(userId);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(AllAthleteList allAthleteList)
        {
            string userId = null;
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == "UserId"))
            {
                userId = currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            }
            allAthleteList.coachId = userId;
            var query = unitOfWork.SportsService.GetAllAthlete().ToList();
            if (ModelState.IsValid)
            {
                foreach (var item in query)
                {
                    if(item.athlete_name == allAthleteList.athlete_name && item.coachId == userId)
                    {
                        ViewBag.message = "Athlete already exists";
                        return BadRequest();
                    }
                }
                unitOfWork.SportsService.addAthlete(allAthleteList);
                unitOfWork.commit();
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public AllAthleteList Delete(int id)
        {
            var athleteList = unitOfWork.SportsService.GetAthleteName(id).FirstOrDefault();
            if(athleteList == null)
            {
                return null;
            }
            return athleteList;
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                unitOfWork.SportsService.deleteAthlete(id);
                unitOfWork.SportsService.deleteAthleteFromTest(id);
                unitOfWork.commit();
                return Ok();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}