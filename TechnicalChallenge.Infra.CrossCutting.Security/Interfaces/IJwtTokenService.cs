using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalChallenge.Infra.CrossCutting.Security.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(Guid id, string name, string lastName,string email, string pass = null);
    }
}
