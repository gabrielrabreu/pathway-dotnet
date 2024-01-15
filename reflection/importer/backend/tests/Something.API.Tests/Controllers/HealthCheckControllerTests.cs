using Something.API.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Something.API.Tests.Controllers
{
    public class HealthCheckControllerTests
    {
        private readonly HealthCheckController _healthCheckController;

        public HealthCheckControllerTests()
        {
            _healthCheckController = new HealthCheckController();
        }

        [Fact(DisplayName = "Get_ShouldReturnOk")]
        [Trait("Something - Controllers", "HealthCheck")]
        public void Get_ShouldReturnOk()
        {
            // Act
            var result = _healthCheckController.Get();

            // Assert
            var okResult = result as OkResult;
            Assert.NotNull(okResult);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }
    }
}
