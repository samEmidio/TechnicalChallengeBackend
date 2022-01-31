using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Domain.Entities;

namespace TechnicalChallenge.Domain.Interfaces.Repositories
{
    public interface IEventRepository : IBaseRepository<Event>
    {
        IList<Event> GetAll(int take, int skip, Guid UserId);
        IList<Event> GetAllResume(int take, int skip, Guid UserId);
    }
}
