using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Application.ViewModels.Event;
using TechnicalChallenge.Application.ViewModels.User;
using TechnicalChallenge.Domain.Entities;

namespace TechnicalChallenge.Application.Mapper.Event
{
    public class EventMapper : Profile
    {
        public EventMapper()
        {
            CreateMap<CreateEventViewModel, Domain.Entities.Event>();
            CreateMap<EventViewModel, Domain.Entities.Event>();
            CreateMap<Domain.Entities.Event, CreateEventViewModel>();
        }
    }
}
