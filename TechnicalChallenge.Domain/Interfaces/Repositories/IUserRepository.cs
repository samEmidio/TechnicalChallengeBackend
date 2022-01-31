using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Domain.Entities;

namespace TechnicalChallenge.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetByEmail(string email);
        User GetByEmailAndPass(string email, string pass);
    }
}
