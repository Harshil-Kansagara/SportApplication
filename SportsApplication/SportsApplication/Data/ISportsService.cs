using SportsApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsApplication.Data
{
    public interface ISportsService
    {
        IEnumerable<TestList> GetAllTestLists();
        TestList addTestList(TestList newTest);
        IEnumerable<TestList> GetTestListData(int id);
        void deleteTestList(int id);
        TestList GetTestDetail(int id);

        AllAthleteList addAthlete(AllAthleteList newAthlete);
        IEnumerable<AllAthleteList> GetAllAthlete();
        IEnumerable<AllAthleteList> GetAthleteName(int id);
        AllAthleteList deleteAthlete(int id);
        AllAthleteList GetAthleteOnlyName(int athlete_id);

        List<int> GetAthleteId(int testId);
        AthleteByTest addAthleteByTest(AthleteByTest newAthleteByTest);
        List<AthleteByTest> GetAthleteList(int testId);
        int GetAthleteDistance(int id);
        int GetAthleteTableid(int athleteId, int testId);
        void updateAthleteData(EditAthleteDataModel newEditAthlete);
        AthleteByTest deleteAthleteData(int id);
        void deleteAthleteFromTest(int athleteId);
        void GetparticpantCount(int testId);
        void deleteTestAthleteData(int testId);

        int commit();
    }
}
