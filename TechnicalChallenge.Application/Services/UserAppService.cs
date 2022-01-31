using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Application.Interfaces;
using TechnicalChallenge.Application.Validation.User;
using TechnicalChallenge.Application.ViewModels.User;
using TechnicalChallenge.Domain.Core.Bus;
using TechnicalChallenge.Domain.Core.Notifications;
using TechnicalChallenge.Domain.Entities;
using TechnicalChallenge.Domain.Interfaces.Repositories;

namespace TechnicalChallenge.Application.Services
{
    public class UserAppService : BaseAppService, IUserAppService
    {
        private readonly CreateUserValidation _userValidation;
        private readonly IMapper _mapper;

        public UserAppService(IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications,
            CreateUserValidation createUserValidation,
            IMapper mapper) : base(uow, bus, notifications)
        {
            _userValidation = createUserValidation;
            _mapper = mapper;
        }

        public UserViewModel AddIfNotExists(CreateUserViewModel createUserViewModel)
        {
            try
            {
                var isValid = CheckModelErrors(_userValidation.Validate(createUserViewModel));

                if (isValid)
                {
                    var userExists = _uow.Users.GetByEmail(createUserViewModel.Email);
                    if(userExists != null)
                        _bus.RaiseEvent(new DomainNotification("", "Já existe um usuario com esse email"));

                    var user = _mapper.Map<User>(createUserViewModel);

                    BeginTransaction();
                    _uow.Users.Add(user);
                    Commit();

                    return _mapper.Map<UserViewModel>(user);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }

            return null;
        }

        public UserViewModel GetByEmailAndPass(string email, string pass)
        {
            var user = _uow.Users.GetByEmailAndPass(email,pass);
            var userViewModel = _mapper.Map<UserViewModel>(user);
            return userViewModel;
        }

        public UserViewModel GetByEmail(string email)
        {
            var user = _uow.Users.GetByEmail(email);
            var userViewModel = _mapper.Map<UserViewModel>(user);
            return userViewModel;
        }
    }
}
