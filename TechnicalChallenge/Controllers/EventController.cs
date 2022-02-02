using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnicalChallenge.Application.Interfaces;
using TechnicalChallenge.Application.ViewModels.Event;
using TechnicalChallenge.Application.ViewModels.EventUser;
using TechnicalChallenge.Domain.Core.Bus;
using TechnicalChallenge.Domain.Core.Notifications;
using TechnicalChallenge.Infra.CrossCutting.Security.Interfaces;
using TechnicalChallenge.Infra.CrossCutting.Security.Model;

namespace TechnicalChallenge.Controllers
{
	[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EventController : BaseController
    {


		private readonly IMediatorHandler _bus;
		private readonly DomainNotificationHandler _notifications;
		private readonly IConfiguration configuration;
		private readonly ILogger<AccountController> logger;
		private readonly IJwtTokenService jwtTokenService;
		private readonly IEventAppService _eventApplicationService;
		private readonly LoggedUser _loggedUser;
		private readonly IMapper _mapper;

		public EventController(
		   IMediatorHandler bus,
		   IMediatorHandler mediator,
		   INotificationHandler<DomainNotification> notifications,
		   IConfiguration configuration,
		   ILogger<AccountController> logger,
		   IEventAppService eventApplicationService,	
		   IJwtTokenService jwtTokenService,
		   IMapper mapper,
		   LoggedUser loggedUser
		   ) : base(notifications, mediator)
		{
			_notifications = (DomainNotificationHandler)notifications;
			this._bus = bus;
			this.configuration = configuration;
			this.logger = logger;
			this.jwtTokenService = jwtTokenService;
			_eventApplicationService = eventApplicationService;
			_mapper = mapper;
			_loggedUser = loggedUser;
		}


		[HttpPost("create")]
		public IActionResult Create([FromBody] CreateEventViewModel createEventViewModel)
		{
			return Response(_eventApplicationService.Add(createEventViewModel));
		}


		[HttpGet("getAll")]
		public IActionResult GetAll(int take = 10,int skip = 0)
        {
			return Response(_eventApplicationService.GetAll(take,skip));
        }

		[HttpGet("getAllResume")]
		public IActionResult GetAllResume(int take = 10, int skip = 0)
		{
			return Response(_eventApplicationService.GetAllResume(take, skip));
		}


		[HttpDelete("remove/{id}")]
		public IActionResult Remove(Guid id)
		{
			_eventApplicationService.Remove(id);
			return Response();
		}


		[HttpPost("addUser")]
		public IActionResult SaveEventUser([FromBody] CreateEventUserViewModel createEventUserViewModel)
        {
			return Response(_eventApplicationService.AddUser(createEventUserViewModel));
        }


		[HttpGet("getAllEventUsers/{eventId}")]
		public IActionResult GetAllEventUsers([FromRoute] Guid eventId,int take = 10, int skip = 0)
		{
			return Response(_eventApplicationService.GetAllEventUsers(take, skip, eventId));
		}

		[HttpPut("updateIsPaidEventUser/{id}/{isPaid}")]
		public IActionResult UpdateIsPaidEventUser(Guid id,bool isPaid)
        {
			return Response(_eventApplicationService.UpdateIsPaidEventUser(id, isPaid));
        }

		[HttpGet("getResumeDetail/{eventId}")]
		public IActionResult GetResumeDetail(Guid eventId)
		{
			return Response(_eventApplicationService.GetResumeDetail(eventId));
		}

		[HttpDelete("remove/eventUser/{id}")]
		public IActionResult RemoveEventUser(Guid id)
		{
			_eventApplicationService.RemoveEventUser(id);
			return Response();
		}

	}
}
