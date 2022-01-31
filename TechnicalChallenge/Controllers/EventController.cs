using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnicalChallenge.Application.Interfaces;
using TechnicalChallenge.Application.ViewModels.Event;
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


	}
}
