using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SportsApplication.Data.Entity;

namespace SportsApplication.Data
{
    public class SportsData
        : ISportsService
    {
        
        private readonly DataDbContext db;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public SportsData(DataDbContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public AllAthleteList addAthlete(AllAthleteList newAthlete)
        {
            db.AllAthleteLists.Add(newAthlete);
            return newAthlete;
        }

        public AthleteByTest addAthleteByTest(AthleteByTest newAthleteByTest)
        {
            db.AthleteByTests.Add(newAthleteByTest);
            return newAthleteByTest;
        }

        public TestList addTestList(TestList newTest)
        {
            db.TestLists.Add(newTest);
            return newTest;
        }

        public AllAthleteList deleteAthlete(int id)
        {
            var athlete = db.AllAthleteLists.Find(id);
            if (athlete != null)
            {
                db.AllAthleteLists.Remove(athlete);
            }
            return athlete;
        }

        public void deleteTestList(int id)
        {
            var test = db.TestLists.Find(id);
            if(test != null)
            {
                db.TestLists.Remove(test);
            }
        }

        public IEnumerable<AllAthleteList> GetAllAthlete()
        {
            return from aa in db.AllAthleteLists
                   select aa;
        }

        public IEnumerable<TestList> GetAllTestLists()
        {
            return from tl in db.TestLists
                   orderby tl.date descending
                   select tl;
        }

        public int GetAthleteDistance(int id)
        {
            return (from at in db.AthleteByTests
                   where at.id == id
                   select at.athlete_distance).FirstOrDefault();
        }

        public List<int> GetAthleteId(int testId)
        {
            return (from at in db.AthleteByTests
                    where at.test_id == testId
                    select at.athlete_id).ToList();
        }

        public List<AthleteByTest> GetAthleteList(int testId)
        {
           return (from aa in db.AthleteByTests
                  where aa.test_id == testId
                  orderby aa.athlete_distance descending
                  select aa).ToList();
        }

        public IEnumerable<AllAthleteList> GetAthleteName(int id)
        {
            return from aa in db.AllAthleteLists
                   where aa.id == id
                   select aa;
        }

        public AllAthleteList GetAthleteOnlyName(int athlete_id)
        {
            return (from aa in db.AllAthleteLists
                    where aa.id == athlete_id
                    select aa).FirstOrDefault();
        }

        public TestList GetTestDetail(int id)
        {
            return (from tl in db.TestLists
                   where tl.id == id
                   select tl).FirstOrDefault();
        }

        public IEnumerable<TestList> GetTestListData(int id)
        {
            return from tl in db.TestLists
                   where tl.id == id
                   select tl;
        }

        public int GetAthleteTableid(int athleteId, int testId)
        {
            return (from at in db.AthleteByTests
                    where at.athlete_id == athleteId && at.test_id == testId
                    select at.id).FirstOrDefault();
        }

        public void updateAthleteData(EditAthleteDataModel newEditAthlete)
        {
            (from at in db.AthleteByTests
             where at.id == newEditAthlete.id
             select at).ToList()
                .ForEach(
                 x =>
                 {
                     x.test_id = newEditAthlete.TestId;
                     x.athlete_id = newEditAthlete.athleteId;
                     x.athlete_distance = newEditAthlete.distance;
                 });
        }

        public AthleteByTest deleteAthleteData(int id)
        {
            var athleteData = db.AthleteByTests.Find(id);
            if (athleteData != null)
            {
                db.AthleteByTests.Remove(athleteData);
            }
            return athleteData;
        }

        public void deleteAthleteFromTest(int athleteId)
        {
            var athleteData = (from at in db.AthleteByTests where at.athlete_id == athleteId select at).ToList();
            if (athleteData != null)
            {
                foreach (var item in athleteData)
                {
                    db.AthleteByTests.Remove(item);
                } 
            }
        }

        public void GetparticpantCount(int testId)
        {
            (from tl in db.TestLists
             where tl.id == testId select tl).ToList()
            .ForEach(
                 x => 
                     x.participant_num = GetAthleteList(testId).Count());
        }

        public void deleteTestAthleteData(int testId)
        {
            var athleteData = (from at in db.AthleteByTests where at.test_id == testId select at).ToList();
            if (athleteData != null)
            {
                foreach (var item in athleteData)
                {
                    db.AthleteByTests.Remove(item);
                }
            }
        }

        public List<TestList> GetTestListsByUserId(string userId)
        {
            return (from tl in db.TestLists
                    where tl.coachId == userId
                   orderby tl.date descending
                   select tl).ToList();
        }

        public List<AllAthleteList> GetAthleteByUserId(string userId)
        {
            return (from aa in db.AllAthleteLists
                    where aa.coachId == userId
                    select aa).ToList();
        }

        public List<AllAthleteList> getAthleteId(string username)
        {
            return (from aa in db.AllAthleteLists
                    where aa.athlete_name.ToString().ToLower() == username.ToLower()
                    select aa).ToList();
        }

        public List<AthleteByTest> GetAthleteTestLists(int athleteId)
        {
            return (from aa in db.AthleteByTests
                    where aa.athlete_id == athleteId
                    select aa).ToList();
        }

        public List<IdentityRole> getAllRoles()
        {
           return roleManager.Roles.ToList();
        }

        public Task<IdentityResult> registerUser(ApplicationUser user, string password)
        {
           return userManager.CreateAsync(user, password);
        }

        public void signInUser(ApplicationUser user)
        {
            signInManager.SignInAsync(user, isPersistent: false);
        }

        public Task<ApplicationUser> GetCurrentUser(ClaimsPrincipal user)
        {
            return userManager.GetUserAsync(user);
        }

        public void logout()
        {
            signInManager.SignOutAsync();
        }

        public Task<ApplicationUser> GetUserById(string userId)
        {
            return userManager.FindByIdAsync(userId);
        }

        public Task<SignInResult> login(LoginViewModel loginView)
        {
            return signInManager.PasswordSignInAsync(loginView.Name, loginView.Password, loginView.RememberMe, false);
        }

        public Task<ApplicationUser> GetCurrentUserDetail(string name)
        { 
            return userManager.FindByNameAsync(name);
        }

        public List<ApplicationUser> GetAllUser()
        {
            return userManager.Users.ToList();
        }
    }
}
