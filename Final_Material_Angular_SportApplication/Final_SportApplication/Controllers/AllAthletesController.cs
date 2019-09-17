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
    public class AllAthletesController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public AllAthletesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("Index")]
        public List<AthleteListModel> Index()
        {
            string userId = null;
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == "UserId"))
            {
                userId = currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            }
            return unitOfWork.SportsService.GetAthleteByUserId(userId);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(AthleteListModel newAthlete)
        {
            string userId = null;
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == "UserId"))
            {
                userId = currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            }
            newAthlete.CoachId = userId;
            var query = unitOfWork.SportsService.GetAllAthlete().ToList();
            if (ModelState.IsValid)
            {
                foreach (var item in query)
                {
                    if (item.AthleteName == newAthlete.AthleteName && item.CoachId == userId)
                    {
                        return BadRequest();
                    }
                }
                unitOfWork.SportsService.addAthlete(newAthlete);
                unitOfWork.commit();
                return Ok();
            }
            return BadRequest();
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}