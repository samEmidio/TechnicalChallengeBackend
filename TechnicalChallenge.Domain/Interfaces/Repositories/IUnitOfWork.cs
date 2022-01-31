using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalChallenge.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IEventRepository Events { get; }
        IEventUserRepository EventUsers { get; }
        IUserRepository Users { get; }       
        int BeginTransaction();
        bool Save();
    }
}
