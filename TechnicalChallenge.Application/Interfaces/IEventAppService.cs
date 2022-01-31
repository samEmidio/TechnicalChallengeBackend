using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Application.ViewModels.Event;
using TechnicalChallenge.Application.ViewModels.EventUser;
using TechnicalChallenge.Domain.DTOs;

namespace TechnicalChallenge.Application.Interfaces
{
    public interface IEventAppService
    {
        EventViewModel Add(CreateEventViewModel createEventViewModel);
        void Remove(Guid id);
        IList<EventViewModel> GetAll(int take, int skip);
        IList<EventResumeDTO> GetAllResume(int take, int skip);
        EventUserViewModel AddUser(CreateEventUserViewModel createEventUserViewModel);
    }
}
