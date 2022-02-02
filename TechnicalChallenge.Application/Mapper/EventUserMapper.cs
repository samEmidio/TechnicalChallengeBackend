using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Application.ViewModels.EventUser;

namespace TechnicalChallenge.Application.Mapper
{
    public class EventUserMapper : Profile
    {
        public EventUserMapper()
        {
            CreateMap<CreateEventUserViewModel, Domain.Entities.EventUser>();
            CreateMap<Domain.Entities.EventUser, CreateEventUserViewModel>();
            CreateMap<EventUserViewModel, Domain.Entities.EventUser>();
            CreateMap<Domain.Entities.EventUser, EventUserViewModel>();
        }
    }
}
