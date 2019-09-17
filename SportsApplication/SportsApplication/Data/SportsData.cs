using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsApplication.Data.Entity;

namespace SportsApplication.Data
{
    public class SportsData
        : ISportsService
    {

        private readonly DataDbContext db;

        public SportsData(DataDbContext db)
        {
            this.db = db;
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

        public int commit()
        {
            return db.SaveChanges();
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
    }
}
