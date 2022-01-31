using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechnicalChallenge.Application.Interfaces;
using TechnicalChallenge.Application.ViewModels.User;
using TechnicalChallenge.Domain.Core.Bus;
using TechnicalChallenge.Domain.Core.Notifications;
using TechnicalChallenge.Domain.Entities;
using TechnicalChallenge.Infra.CrossCutting.Security.Interfaces;
using TechnicalChallenge.Infra.CrossCutting.Security.Model;

namespace TechnicalChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : BaseController
    {
		private readonly IMediatorHandler _bus;
		private readonly DomainNotificationHandler _notifications;
		private readonly IConfiguration configuration;
		private readonly ILogger<AccountController> logger;
		private readonly IJwtTokenService jwtTokenService;
		private readonly IUserAppService _userApplicationService;
		private readonly LoggedUser _loggedUser;
		private readonly IMapper _mapper;

		public AccountController(
		   IMediatorHandler bus,
		   IMediatorHandler mediator,
		   INotificationHandler<DomainNotification> notifications,
		   IConfiguration configuration,
		   ILogger<AccountController> logger,
		   IJwtTokenService jwtTokenService,
		   IUserAppService userApplicationService,
		   IMapper mapper,
		   LoggedUser loggedUser
		   ) : base(notifications, mediator)
		{
			_notifications = (DomainNotificationHandler)notifications;
			this._bus = bus;
			this.configuration = configuration;
			this.logger = logger;
			this.jwtTokenService = jwtTokenService;
			_userApplicationService = userApplicationService;
			_mapper = mapper;
			_loggedUser = loggedUser;
		}


		[HttpPost("register")]
		public IActionResult Register([FromBody] CreateUserViewModel createUserViewModel)
        {
			
			var userViewModel = _userApplicationService.AddIfNotExists(createUserViewModel);

			var user = _mapper.Map<User>(userViewModel);

			var token = jwtTokenService.GenerateToken(user.Id, user.Name, user.LastName, user.Email);

			userViewModel.Token = token;

			return Response(userViewModel);
        }


		[HttpGet("authentication")]
		public IActionResult Authtentication(string email, string pass)
        {
            try
			{
				var userViewModel = _userApplicationService.GetByEmailAndPass(email, pass);
				if (userViewModel == null)
                {
					_bus.RaiseEvent(new DomainNotification("", "Invalid UserName/Password"));
					return Response("Invalid UserName/Password");
				}

				var user = _mapper.Map<User>(userViewModel);

				var token = jwtTokenService.GenerateToken(user.Id, user.Name, user.LastName, user.Email);

				userViewModel.Token = token;

				return Response(userViewModel);
			}
            catch (Exception ex)
            {
				string innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception found";
				return BadRequest($"Exception: {ex.Message ?? "" } - Trace: {ex.StackTrace ?? "" } - Inner Exception: {innerException}");
			}


        }

	


	}
}
