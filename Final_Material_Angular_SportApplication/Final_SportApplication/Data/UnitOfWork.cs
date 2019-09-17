using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_SportApplication.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataDbContext db;
        public ISportService SportsService { get; private set; }

        public ISportService sportService => throw new NotImplementedException();

        public UnitOfWork(DataDbContext db, ISportService sportService)
        {
            this.db = db;
            SportsService = sportService;
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
