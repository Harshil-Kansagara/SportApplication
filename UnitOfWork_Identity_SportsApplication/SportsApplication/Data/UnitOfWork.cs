using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsApplication.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataDbContext db;
        public ISportsService SportsService { get; private set;}
        
        public UnitOfWork(DataDbContext db, ISportsService sportsService)
        {
            this.db = db;
            SportsService = sportsService; 
        }

        public int commit()
        {
            return db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
