using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Domain.Entities;

namespace TechnicalChallenge.Domain.Interfaces.Repositories
{
    public interface IEventUserRepository : IBaseRepository<EventUser>
    {
        IList<EventUser> GetAll(int take, int skip, Guid eventId);
    }
}
