using Final_SportApplication.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_SportApplication.Data
{
    public class SportService : ISportService
    {
        private readonly DataDbContext db;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public SportService(DataDbContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public List<IdentityRole> getAllRoles()
        {
            return roleManager.Roles.ToList();
        }

        public Task<IdentityResult> registerUser(ApplicationUser user, string password)
        {
            return userManager.CreateAsync(user, password);
        }

        public Task<SignInResult> login(LoginModel loginView)
        {
            return signInManager.PasswordSignInAsync(loginView.Name, loginView.Password, loginView.RememberMe, false);
        }

        public Task<ApplicationUser> GetCurrentUserDetail(string name)
        {
            return userManager.FindByNameAsync(name);
        }

        public List<TestListModel> GetTestListsByUserId(string userId)
        {
            return (from tl in db.TestList
                    where tl.CoachId == userId
                    orderby tl.Date descending
                    select tl).ToList();
        }

        public void GetparticpantCount(int testId)
        {
            (from tl in db.TestList
             where tl.Id == testId
             select tl).ToList()
            .ForEach(
                 x =>
                     x.ParticipantNumber = GetAthleteList(testId).Count());
        }

        public List<AthleteByTestModel> GetAthleteList(int testId)
        {
            return (from aa in db.AthleteByTest
                    where aa.TestId == testId
                    orderby aa.AthleteDistance descending
                    select aa).ToList();
        }

        public IEnumerable<TestListModel> GetAllTestLists()
        {
            return from tl in db.TestList
                   orderby tl.Date descending
                   select tl;
        }

        public TestListModel addTestList(TestListModel newTest)
        {
            db.TestList.Add(newTest);
            return newTest;
        }

        public void deleteTestList(int id)
        {
            var test = db.TestList.Find(id);
            if (test != null)
            {
                db.TestList.Remove(test);
            }
        }

        public void deleteTestAthleteData(int testId)
        {
            var athleteData = (from at in db.AthleteByTest where at.TestId == testId select at).ToList();
            if (athleteData != null)
            {
                foreach (var item in athleteData)
                {
                    db.AthleteByTest.Remove(item);
                }
            }
        }

        public List<AthleteListModel> GetAthleteByUserId(string userId)
        {
            return (from aa in db.AthleteList
                    where aa.CoachId == userId
                    select aa).ToList();
        }

        public IEnumerable<AthleteListModel> GetAllAthlete()
        {
            return from aa in db.AthleteList
                   select aa;
        }

        public AthleteListModel addAthlete(AthleteListModel newAthlete)
        {
            db.AthleteList.Add(newAthlete);
            return newAthlete;
        }

        public AthleteListModel deleteAthlete(int id)
        {
            var athlete = db.AthleteList.Find(id);
            if (athlete != null)
            {
                db.AthleteList.Remove(athlete);
            }
            return athlete;
        }

        public void deleteAthleteFromTest(int athleteId)
        {
            var athleteData = (from at in db.AthleteByTest where at.AthleteId == athleteId select at).ToList();
            if (athleteData != null)
            {
                foreach (var item in athleteData)
                {
                    db.AthleteByTest.Remove(item);
                }
            }
        }

        public TestListModel GetTestDetail(int id)
        {
            return (from tl in db.TestList
                    where tl.Id == id
                    select tl).FirstOrDefault();
        }

        public AthleteByTestModel addAthleteByTest(AthleteByTestModel newAthleteByTest)
        {
            db.AthleteByTest.Add(newAthleteByTest);
            return newAthleteByTest;
        }

        public int GetAthleteDistance(int id)
        {
            return (from at in db.AthleteByTest
                    where at.Id == id
                    select at.AthleteDistance).FirstOrDefault();
        }

        public int GetAthleteTableid(int athleteId, int testId)
        {
            return (from at in db.AthleteByTest
                    where at.AthleteId == athleteId && at.TestId == testId
                    select at.Id).FirstOrDefault();
        }

        public void updateAthleteData(EditAthleteDataModel newEditAthlete)
        {
            (from at in db.AthleteByTest
             where at.Id == newEditAthlete.Id
             select at).ToList()
               .ForEach(
                x =>
                {
                    x.TestId = newEditAthlete.TestId;
                    x.AthleteId = newEditAthlete.AthleteId;
                    x.AthleteDistance = newEditAthlete.Distance;
                });
        }

        public AthleteByTestModel deleteAthleteData(int id)
        {
            var athleteData = db.AthleteByTest.Find(id);
            if (athleteData != null)
            {
                db.AthleteByTest.Remove(athleteData);
            }
            return athleteData;
        }

        public List<AthleteListModel> getAthleteId(string username)
        {
            return (from aa in db.AthleteList
                    where aa.AthleteName.ToString().ToLower() == username.ToLower()
                    select aa).ToList();
        }

        public List<AthleteByTestModel> GetAthleteTestLists(int athleteId)
        {
            return (from aa in db.AthleteByTest
                    where aa.AthleteId == athleteId
                    select aa).ToList();
        }

        public List<ApplicationUser> GetAllUser()
        {
            return userManager.Users.ToList();
        }
    }
}
