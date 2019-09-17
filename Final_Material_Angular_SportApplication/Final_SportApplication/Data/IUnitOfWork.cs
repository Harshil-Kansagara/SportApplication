using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_SportApplication.Data
{
    public interface IUnitOfWork : IDisposable 
    {
        ISportService SportsService { get; }
        int commit();
    }
}
