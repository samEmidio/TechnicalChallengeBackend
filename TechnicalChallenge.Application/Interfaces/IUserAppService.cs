using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Application.ViewModels.User;

namespace TechnicalChallenge.Application.Interfaces
{
    public interface IUserAppService
    {
        UserViewModel AddIfNotExists(CreateUserViewModel createUserViewModel);
        UserViewModel GetByEmailAndPass(string email, string pass);
        UserViewModel GetByEmail(string email);
    }
}
