using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Application.Interfaces;
using TechnicalChallenge.Application.Services;
using TechnicalChallenge.Application.Validation.Event;
using TechnicalChallenge.Application.Validation.EventUser;
using TechnicalChallenge.Application.Validation.User;
using TechnicalChallenge.Domain.Core.Bus;
using TechnicalChallenge.Domain.Core.Notifications;
using TechnicalChallenge.Domain.Interfaces.Repositories;
using TechnicalChallenge.Infra.CrossCutting.Bus;
using TechnicalChallenge.Infra.CrossCutting.Security.Interfaces;
using TechnicalChallenge.Infra.CrossCutting.Security.Model;
using TechnicalChallenge.Infra.CrossCutting.Security.Services;
using TechnicalChallenge.Infra.Data.Context;
using TechnicalChallenge.Infra.Data.Repositories;
using TechnicalChallenge.Infra.Data.UnitOfWork;

namespace TechnicalChallenge.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IEventAppService, EventAppService>();



            // Application DTO Validators
            services.AddTransient<CreateUserValidation>();
            services.AddTransient<CreateEventValidation>();
            services.AddTransient<CreateEventUserValidation>();


            // Domain
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventUserRepository, EventUserRepository>();


            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<TechnicalChallengeContext>();
            
           

            //CrossCutting = Security
            services.AddScoped<LoggedUser>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
        }
    }
}
