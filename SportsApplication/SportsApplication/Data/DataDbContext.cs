using Microsoft.EntityFrameworkCore;
using SportsApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsApplication.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options)
            : base(options)
        {
        }

        public DbSet<AllAthleteList> AllAthleteLists { get; set; }
        public DbSet<TestList> TestLists { get; set; }
        public DbSet<AthleteByTest> AthleteByTests { get; set; }
    }
}
