using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Application.ViewModels.User;


namespace TechnicalChallenge.Application.Mapper.User
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<CreateUserViewModel, Domain.Entities.User>();
            CreateMap<UserViewModel, Domain.Entities.User>();
            CreateMap<Domain.Entities.User, UserViewModel>();
        }
    }
}
