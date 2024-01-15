using Core.Domain.Notifications;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;

namespace Core.Domain.Tests.Notifications
{
    public class DomainNotificationHandlerTests
    {
        private readonly DomainNotificationHandler _notifications;

        public DomainNotificationHandlerTests()
        {
            _notifications = new DomainNotificationHandler();
        }

        [Fact(DisplayName = "Handle_ShouldAddDomainNotification")]
        [Trait("Core - Notifications", "DomainNotificationHandler")]
        public void Handle_ShouldAddDomainNotification()
        {
            // Arrange
            var notification = new DomainNotification("Key", "Value");

            // Act
            _notifications.Handle(notification, new CancellationToken());

            // Assert
            Assert.Single(_notifications.GetNotifications());
            Assert.Equal(notification, _notifications.GetNotifications().Single());
        }

        [Fact(DisplayName = "GetNotifications_ShouldReturnDomainNotificationList_WhenHaveDomainNotifications")]
        [Trait("Core - Notifications", "DomainNotificationHandler")]
        public void GetNotifications_ShouldReturnDomainNotificationList_WhenHaveDomainNotifications()
        {
            // Arrange
            var domainNotificationOne = new DomainNotification("KeyOne", "ValueOne");
            var domainNotificationTwo = new DomainNotification("KeyTwo", "ValueTwo");
            var domainNotifications = new List<DomainNotification>() { domainNotificationOne, domainNotificationTwo };
            _notifications.Handle(domainNotificationOne, new CancellationToken());
            _notifications.Handle(domainNotificationTwo, new CancellationToken());

            // Act
            var result = _notifications.GetNotifications();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(domainNotifications, result);
        }

        [Fact(DisplayName = "GetNotifications_ShouldReturnEmptyDomainNotificationList_WhenDontHaveDomainNotifications")]
        [Trait("Core - Notifications", "DomainNotificationHandler")]
        public void GetNotifications_ShouldReturnEmptyDomainNotificationList_WhenDontHaveDomainNotifications()
        {
            // Act
            var result = _notifications.GetNotifications();

            // Assert
            Assert.Empty(result);
        }

        [Fact(DisplayName = "HasNotifications_ShouldReturnTrue_WhenHaveAtLeastOneDomainNotification")]
        [Trait("Core - Notifications", "DomainNotificationHandler")]
        public void HasNotifications_ShouldReturnTrue_WhenHaveAtLeastOneDomainNotification()
        {
            // Arrange
            var domainNotification = new DomainNotification("Key", "Value");
            _notifications.Handle(domainNotification, new CancellationToken());

            // Act
            var result = _notifications.HasNotifications();

            // Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "HasNotifications_ShouldReturnFalse_WhenEmptyDomainNotificationList")]
        [Trait("Core - Notifications", "DomainNotificationHandler")]
        public void HasNotifications_ShouldReturnFalse_WhenEmptyDomainNotificationList()
        {
            // Act
            var result = _notifications.HasNotifications();

            // Assert
            Assert.False(result);
        }
    }
}
