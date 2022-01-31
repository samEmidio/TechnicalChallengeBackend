using System.Security.Claims;
using TechnicalChallenge.Application.Interfaces;
using TechnicalChallenge.Infra.CrossCutting.Security.Model;

namespace TechnicalChallenge.Middlewares
{
    public class UserIndentificationMiddleware : IMiddleware
    {
        private readonly IUserAppService _userAppService;
        private readonly LoggedUser _loggedUser;
        private readonly IHttpContextAccessor _accessor;

        public UserIndentificationMiddleware(
            IHttpContextAccessor accessor,
            IUserAppService userAppService,
            LoggedUser loggedUser)
        {
            _accessor = accessor;
            _userAppService = userAppService;
            _loggedUser = loggedUser;
        }

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var identity = context.User.Identity as ClaimsIdentity;
            if (identity.HasClaim(c => c.Type == ClaimTypes.Email))
            {
                var email = identity.FindFirst(ClaimTypes.Email).Value;

                var user = _userAppService.GetByEmail(email);
                _loggedUser.Id = user.Id;
                _loggedUser.Name = user.Name;
                _loggedUser.Email = user.Email;
                
            }
            return next.Invoke(context);
        }
    }

    public static class UserIndentificationMiddlewareExtension
    {
        public static IApplicationBuilder UserIndentificationMiddleware(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<UserIndentificationMiddleware>();
        }

        public static void AddService(this IServiceCollection services)
        {
            services.AddTransient<UserIndentificationMiddleware>();
        }
    }

}
