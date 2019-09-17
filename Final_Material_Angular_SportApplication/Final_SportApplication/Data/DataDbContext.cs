using Final_SportApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_SportApplication.Data
{
    public class DataDbContext : IdentityDbContext<ApplicationUser>
    {
        public DataDbContext(DbContextOptions<DataDbContext> options)
            : base(options)
        {

        }

        public DbSet<AthleteListModel> AthleteList { get; set; }
        public DbSet<TestListModel> TestList { get; set; }
        public DbSet<AthleteByTestModel> AthleteByTest { get; set; }
    }
}
