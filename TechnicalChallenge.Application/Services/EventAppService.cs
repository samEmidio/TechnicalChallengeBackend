using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Application.Interfaces;
using TechnicalChallenge.Application.Validation.Event;
using TechnicalChallenge.Application.Validation.EventUser;
using TechnicalChallenge.Application.ViewModels.Event;
using TechnicalChallenge.Application.ViewModels.EventUser;
using TechnicalChallenge.Domain.Core.Bus;
using TechnicalChallenge.Domain.Core.Notifications;
using TechnicalChallenge.Domain.DTOs;
using TechnicalChallenge.Domain.Entities;
using TechnicalChallenge.Domain.Interfaces.Repositories;
using TechnicalChallenge.Infra.CrossCutting.Security.Model;

namespace TechnicalChallenge.Application.Services
{
    public class EventAppService : BaseAppService, IEventAppService
    {
        private readonly CreateEventValidation _eventValidation;
        private readonly CreateEventUserValidation _eventUserValidation;
        private readonly IMapper _mapper;
        private readonly LoggedUser _loggedUser;

        public EventAppService(IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications,
            CreateEventValidation createEventValidation,
            CreateEventUserValidation createEventUserValidation,
            IMapper mapper,
            LoggedUser loggeUser) : base(uow, bus, notifications)
        {
            _eventValidation = createEventValidation;
            _mapper = mapper;
            _loggedUser = loggeUser;
            _eventUserValidation = createEventUserValidation;
        }


        public EventViewModel Add(CreateEventViewModel createEventViewModel)
        {
            try
            {
                var isValid = CheckModelErrors(_eventValidation.Validate(createEventViewModel));

                if (isValid)
                {
                    var event_ = _mapper.Map<Event>(createEventViewModel);

                    BeginTransaction();
                    _uow.Events.Add(event_);
                    Commit();

                    return _mapper.Map<EventViewModel>(event_);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }

            return null;
        }


        public IList<EventResumeDTO> GetAllResume(int take, int skip)
        {
            var events = _uow.Events.GetAllResume(take, skip, _loggedUser.Id);

            IList<EventResumeDTO> resumes = new List<EventResumeDTO>();

            foreach(var event_ in events)
            {
                var resume = new EventResumeDTO();
                resume.EventId = event_.Id;
                resume.Description = event_.Description;
                resume.AdditionalInformation = event_.AdditionalInformation;
                resume.Date = event_.Date;
                resume.TotalPaid = event_.EventUsers.Sum(x => x.Value);
                resume.TotalUsers = event_.EventUsers.Count();
                resumes.Add(resume);
            }

            return resumes;
        }

        public IList<EventViewModel> GetAll(int take,int skip)
        {
            var events = _uow.Events.GetAll(take, skip,_loggedUser.Id);
            var eventsViewModel = _mapper.Map<IList<EventViewModel>>(events);
            return eventsViewModel;
        }

        public void Remove(Guid id)
        {
            var event_ = _uow.Events.GetById(id);
            if (event_ is null)
                _bus.RaiseEvent(new DomainNotification("", "O evento não foi encontrado."));
            BeginTransaction();
            _uow.Events.Remove(id);
            Commit();
        }



        public EventUserViewModel AddUser(CreateEventUserViewModel createEventUserViewModel)
        {

            try
            {
                var isValid = CheckModelErrors(_eventUserValidation.Validate(createEventUserViewModel));

                if (isValid)
                {
                    var eventUser = _mapper.Map<EventUser>(createEventUserViewModel);

                    BeginTransaction();
                    _uow.EventUsers.Add(eventUser);
                    Commit();

                    return _mapper.Map<EventUserViewModel>(eventUser);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }

            return null;

        }


        public IList<EventUserViewModel> GetAllEventUsers(int take, int skip)
        {
            var eventUsers = _uow.EventUsers.GetAll(take, skip, _loggedUser.Id);
            var eventUsersViewModel = _mapper.Map<IList<EventUserViewModel>>(eventUsers);
            return eventUsersViewModel;
        }


    }
}
