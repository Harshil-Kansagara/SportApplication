using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportsApplication.Data;
using SportsApplication.Data.Entity;

namespace SportsApplication.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AthleteDetailsController : Controller
    {
        private IUnitOfWork unitOfWork;

        public AthleteDetailsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("Index")]
        public AthleteDetailsModel Index()
        {
            string username = null;
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == "UserName"))
            {
                username = currentUser.Claims.FirstOrDefault(c => c.Type == "UserName").Value;
            }
            var athleteId = unitOfWork.SportsService.getAthleteId(username);
            var model = new AthleteDetailsModel();
            foreach(var id in athleteId)
            {
                var testlists = (unitOfWork.SportsService.GetAthleteTestLists(id.id));
                foreach (var item in testlists)
                {
                    model.athleteByTests.Add(item);
                }
            }
            model.testLists = unitOfWork.SportsService.GetAllTestLists().ToList();
            model.coach = unitOfWork.SportsService.GetAllUser();

            return model;
        }
    }
}