using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Domain.Entities;
using TechnicalChallenge.Domain.Interfaces.Repositories;
using TechnicalChallenge.Infra.Data.Context;

namespace TechnicalChallenge.Infra.Data.Repositories
{
    public class EventUserRepository : BaseRepository<EventUser>, IEventUserRepository
    {
        protected readonly TechnicalChallengeContext _context;

        public EventUserRepository(TechnicalChallengeContext context)
            : base(context)
        {
            _context = context;
        }


        public IList<EventUser> GetAll(int take, int skip, Guid eventId)
        {
            return _context.EventUsers.Where(x => x.EventId == eventId).Skip(skip).Take(take).ToList();
        }
    }
}
