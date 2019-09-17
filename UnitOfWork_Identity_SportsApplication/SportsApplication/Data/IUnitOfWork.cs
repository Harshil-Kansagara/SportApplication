using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsApplication.Data
{
    public interface IUnitOfWork : IDisposable
    {
        ISportsService SportsService { get; }
        int commit();
    }
}
