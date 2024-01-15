using Core.Domain.Notifications;
using Core.API.Common;
using Core.API.Controllers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Core.API.Tests.Controllers
{
    public class BaseControllerTests
    {
        private readonly Mock<DomainNotificationHandler> _mockNotifications;
        private readonly MyBaseControllerConcreteClass _myBaseControllerConcreteClass;

        public BaseControllerTests()
        {
            _mockNotifications = new Mock<DomainNotificationHandler>();
            _myBaseControllerConcreteClass = new MyBaseControllerConcreteClass(_mockNotifications.Object);
        }

        [Fact(DisplayName = "Response_ShouldReturnOk")]
        [Trait("Core - Controllers", "BaseController")]
        public void Response_ShouldReturnOk()
        {
            // Arrange
            _mockNotifications.Setup(e => e.HasNotifications()).Returns(false);

            // Act
            var result = _myBaseControllerConcreteClass.TestResponse();

            // Assert
            var okResult = result as OkResult;
            Assert.NotNull(okResult);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact(DisplayName = "Response_ShouldReturnUnprocessableEntity")]
        [Trait("Core - Controllers", "BaseController")]
        public void Response_ShouldReturnUnprocessableEntity()
        {
            // Arrange
            _mockNotifications.Setup(e => e.HasNotifications()).Returns(true);
            var domainNotificationOne = new DomainNotification("KeyOne", "ValueOne");
            var domainNotificationTwo = new DomainNotification("KeyTwo", "ValueTwo");
            var domainNotifications = new List<DomainNotification>() { domainNotificationOne, domainNotificationTwo };
            _mockNotifications.Setup(e => e.GetNotifications()).Returns(domainNotifications);

            // Act
            var result = _myBaseControllerConcreteClass.TestResponse();

            // Assert
            var unprocessableEntityObjectResult = result as UnprocessableEntityObjectResult;
            Assert.NotNull(unprocessableEntityObjectResult);
            Assert.Equal(StatusCodes.Status422UnprocessableEntity, unprocessableEntityObjectResult.StatusCode);

            var unprocessableEntityResponse = unprocessableEntityObjectResult.Value as UnprocessableEntityResponse;
            Assert.NotNull(unprocessableEntityResponse);
            Assert.Equal(2, unprocessableEntityResponse.Errors.Count());
            Assert.Equal(domainNotifications.Select(x => x.Value), unprocessableEntityResponse.Errors);
        }
    }

    public class MyBaseControllerConcreteClass : BaseController
    {
        public MyBaseControllerConcreteClass(INotificationHandler<DomainNotification> notifications)
            : base(notifications) { }

        public IActionResult TestResponse()
        {
            return Response();
        }
    }
}
