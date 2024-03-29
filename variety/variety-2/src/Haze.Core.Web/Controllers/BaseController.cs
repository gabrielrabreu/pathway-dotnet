﻿using Haze.Core.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Haze.Core.Web.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;

        protected BaseController(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        private IEnumerable<string> GetValidationErrors()
        {
            return _notifications.GetNotifications().Select(c => c.Value);
        }

        private bool ValidOperation()
        {
            return !_notifications.HasNotifications();
        }

        protected new IActionResult Response()
        {
            if (ValidOperation())
            {
                return Ok();
            }
            else
            {
                return UnprocessableEntity(new
                {
                    errors = GetValidationErrors()
                });
            }
        }
    }
}