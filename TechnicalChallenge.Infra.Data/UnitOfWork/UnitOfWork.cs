using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Domain.Interfaces.Repositories;
using TechnicalChallenge.Infra.Data.Context;

namespace TechnicalChallenge.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TechnicalChallengeContext _context;
        private int _transactionCount;

        public UnitOfWork(TechnicalChallengeContext context,
            IEventRepository events,
            IUserRepository users,
            IEventUserRepository eventUsers
        )
        {
            _context = context;
            Events = events;
            Users = users;
            EventUsers = eventUsers;   
        }

        public IEventRepository Events { get; private set; }
        public IUserRepository Users { get; private set; }
        public IEventUserRepository EventUsers { get; private set; }


        public bool Save()
        {
            if (_transactionCount <= 1)
            {
                _transactionCount = 0;
                return _context.SaveChanges() > 0;
            }

            _transactionCount--;
            return true;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int BeginTransaction()
        {
            return ++_transactionCount;
        }
    }
}
