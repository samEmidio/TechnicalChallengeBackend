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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        protected readonly TechnicalChallengeContext _context;

        public UserRepository(TechnicalChallengeContext context)
            : base(context)
        {
            _context = context;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }


        public User GetByEmailAndPass(string email,string pass)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email && x.Pass == pass);
        }

    }
}
