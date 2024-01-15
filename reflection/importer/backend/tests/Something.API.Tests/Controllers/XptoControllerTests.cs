using Something.API.Controllers;
using Something.Application.DataTransferObjects.XptoDtos;
using Something.Application.Interfaces;
using Core.Domain.Notifications;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Something.API.Tests.Controllers
{
    public class XptoControllerTests
    {
        private readonly Mock<DomainNotificationHandler> _mockNotifications;
        private readonly Mock<IXptoAppService> _mockXptoAppService;
        private readonly XptoController _xptoController;

        public XptoControllerTests()
        {
            _mockNotifications = new Mock<DomainNotificationHandler>();
            _mockXptoAppService = new Mock<IXptoAppService>();
            _xptoController = new XptoController(
                _mockNotifications.Object, 
                _mockXptoAppService.Object);
        }

        [Fact(DisplayName = "Get_ShouldReturnEmptyXptoDtoList_WhenAppServiceReturnsEmptyDtoList")]
        [Trait("Something - Controllers", "Xpto")]
        public async Task Get_ShouldReturnEmptyXptoDtoList_WhenAppServiceReturnsEmptyDtoList()
        {
            // Arrange
            _mockXptoAppService.Setup(e => e.GetAll()).ReturnsAsync(new List<XptoDto>());

            // Act
            var result = await _xptoController.Get();

            // Assert
            Assert.Empty(result);
        }

        [Fact(DisplayName = "Get_ShouldReturnXptoDtoList_WhenAppServiceReturnsDtoList")]
        [Trait("Something - Controllers", "Xpto")]
        public async Task Get_ShouldReturnXptoDtoList_WhenAppServiceReturnsDtoList()
        {
            // Arrange
            var xptoDtoOne = new XptoDto();
            var xptoDtoTwo = new XptoDto();
            var xptoList = new List<XptoDto>() { xptoDtoOne, xptoDtoTwo };
            _mockXptoAppService.Setup(e => e.GetAll()).ReturnsAsync(xptoList);

            // Act
            var result = await _xptoController.Get();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal(xptoList, result);
        }

        [Fact(DisplayName = "GetById_ShouldReturnNull_WhenAppServiceReturnsNull")]
        [Trait("Something - Controllers", "Xpto")]
        public async Task GetById_ShouldReturnNull_WhenAppServiceReturnsNull()
        {
            // Arrange
            var id = Guid.NewGuid();
            _mockXptoAppService.Setup(e => e.GetById(id)).ReturnsAsync((XptoDto)null);

            // Act
            var result = await _xptoController.GetById(id);

            // Assert
            Assert.Null(result);
        }

        [Fact(DisplayName = "GetById_ShouldReturnDto_WhenAppServiceReturnsDto")]
        [Trait("Something - Controllers", "Xpto")]
        public async Task GetById_ShouldReturnDto_WhenAppServiceReturnsDto()
        {
            // Arrange
            var id = Guid.NewGuid();
            var xptoDto = new XptoDto();
            _mockXptoAppService.Setup(e => e.GetById(id)).ReturnsAsync(xptoDto);

            // Act
            var result = await _xptoController.GetById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(xptoDto, result);
        }

        [Fact(DisplayName = "Add_ShouldCallAppServiceAddAndReturnResponse")]
        [Trait("Something - Controllers", "Xpto")]
        public async Task Add_ShouldCallAppServiceAddAndReturnResponse()
        {
            // Arrange
            var addXptoDto = new AddXptoDto();

            // Act
            var result = await _xptoController.Add(addXptoDto);

            // Assert
            _mockXptoAppService.Verify(e => e.Add(addXptoDto), Times.Once);
            Assert.NotNull(result);
        }
    }
}
