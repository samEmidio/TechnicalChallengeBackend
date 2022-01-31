using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Domain.Core.Bus;
using TechnicalChallenge.Domain.Core.Entity;
using TechnicalChallenge.Domain.Core.Notifications;
using TechnicalChallenge.Domain.Interfaces.Repositories;
using FluentValidation.Results;
using Serilog;
using Serilog.Events;

namespace TechnicalChallenge.Application.Services
{
	public class BaseAppService
	{
		protected readonly IUnitOfWork _uow;
		protected readonly IMediatorHandler _bus;
		protected readonly DomainNotificationHandler _notifications;
		private readonly IBaseRepository<BaseEntity> _repository;

		public BaseAppService(IUnitOfWork uow,IMediatorHandler bus,INotificationHandler<DomainNotification> notifications)
		{
			_uow = uow;
			_bus = bus;
			_notifications = (DomainNotificationHandler)notifications;
		}

		public bool CheckModelErrors(ValidationResult result)
		{
			if (result.Errors.Count > 0)
			{
				foreach (var error in result.Errors)
				{
					_bus.RaiseEvent<DomainNotification>(new DomainNotification(
						"ValidationError", error.ErrorMessage
					));
				}

				return false;
			}

			return true;
		}

		public int BeginTransaction()
		{
			return _uow.BeginTransaction();
		}

		public bool Commit()
		{
			if (_notifications.HasNotifications()) return false;
			if (_uow.Save()) return true;

			_bus.RaiseEvent(new DomainNotification("Commit", "We had a problem during saving your data."));
			return false;
		}


		public void LogException(Exception ex)
		{
			var errorNumber = Guid.NewGuid().ToString();

			Log.Write(LogEventLevel.Error, $"Exception: {errorNumber} - {ex.Message} - Trace: {(ex.StackTrace != null ? ex.StackTrace : "")}");

			_bus.RaiseEvent<DomainNotification>(new DomainNotification("","A ação nao pode ser completada"));
		}

	}
}
