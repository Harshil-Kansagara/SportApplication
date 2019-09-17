using Microsoft.AspNetCore.Identity;
using SportsApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SportsApplication.Data
{
    public interface ISportsService
    {
        IEnumerable<TestList> GetAllTestLists();
        List<TestList> GetTestListsByUserId(string userId);
        TestList addTestList(TestList newTest);
        IEnumerable<TestList> GetTestListData(int id);
        void deleteTestList(int id);
        TestList GetTestDetail(int id);

        List<AllAthleteList> getAthleteId(string username);
        AllAthleteList addAthlete(AllAthleteList newAthlete);
        IEnumerable<AllAthleteList> GetAllAthlete();
        //List<AllAthleteList> GetAllAthleteByUserId(string userId);
        List<AllAthleteList> GetAthleteByUserId(string userId);
        IEnumerable<AllAthleteList> GetAthleteName(int id);
        AllAthleteList deleteAthlete(int id);
        AllAthleteList GetAthleteOnlyName(int athlete_id);

        List<int> GetAthleteId(int testId);
        AthleteByTest addAthleteByTest(AthleteByTest newAthleteByTest);
        List<AthleteByTest> GetAthleteList(int testId);
        List<AthleteByTest> GetAthleteTestLists(int athleteId);
        int GetAthleteDistance(int id);
        int GetAthleteTableid(int athleteId, int testId);
        void updateAthleteData(EditAthleteDataModel newEditAthlete);
        AthleteByTest deleteAthleteData(int id);
        void deleteAthleteFromTest(int athleteId);
        void GetparticpantCount(int testId);
        void deleteTestAthleteData(int testId);

        List<IdentityRole> getAllRoles();
        Task<IdentityResult> registerUser(ApplicationUser user, string password);
        void signInUser(ApplicationUser user);
        Task<ApplicationUser> GetCurrentUser(ClaimsPrincipal user);
        Task<ApplicationUser> GetUserById(string userId);
        Task<SignInResult> login(LoginViewModel loginView);
        Task<ApplicationUser> GetCurrentUserDetail(string name);
        List<ApplicationUser> GetAllUser();
        void logout();

    }
}
