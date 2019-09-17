using Final_SportApplication.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_SportApplication.Data
{
    public interface ISportService
    {
        List<IdentityRole> getAllRoles();
        Task<IdentityResult> registerUser(ApplicationUser user, string password);
        Task<SignInResult> login(LoginModel loginView);
        Task<ApplicationUser> GetCurrentUserDetail(string name);
        List<ApplicationUser> GetAllUser();

        IEnumerable<TestListModel> GetAllTestLists();
        TestListModel addTestList(TestListModel newTest);
        List<TestListModel> GetTestListsByUserId(string userId);
        void GetparticpantCount(int testId);
        void deleteTestList(int id);
        TestListModel GetTestDetail(int id);

        List<AthleteListModel> getAthleteId(string username);
        List<AthleteListModel> GetAthleteByUserId(string userId);
        AthleteListModel addAthlete(AthleteListModel newAthlete);
        IEnumerable<AthleteListModel> GetAllAthlete();
        AthleteListModel deleteAthlete(int id);

        List<AthleteByTestModel> GetAthleteList(int testId);
        void deleteAthleteFromTest(int athleteId);
        AthleteByTestModel addAthleteByTest(AthleteByTestModel newAthleteByTest);
        int GetAthleteDistance(int id);
        int GetAthleteTableid(int athleteId, int testId);
        void updateAthleteData(EditAthleteDataModel newEditAthlete);
        AthleteByTestModel deleteAthleteData(int id);
        List<AthleteByTestModel> GetAthleteTestLists(int athleteId);

        void deleteTestAthleteData(int testId);
    }
}
