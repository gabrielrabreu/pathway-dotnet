using AutoMapper;
using Something.Application.DataTransferObjects.XptoDtos;
using Something.Application.Interfaces;
using Something.Application.Services;
using Something.Domain.Commands.XptoCommands;
using Core.Domain.Mediator;
using Something.Domain.Entities;
using Something.Domain.Interfaces;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Something.Application.Tests.Services
{
    public class XptoAppServiceTests
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IMediatorHandler> _mockMediatorHandler;
        private readonly IXptoAppService _xptoAppService;

        public XptoAppServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockMediatorHandler = new Mock<IMediatorHandler>();
            _xptoAppService = new XptoAppService(
                _mockMapper.Object,
                _mockMediatorHandler.Object,
                new Mock<IXptoRepository>().Object);
        }

        [Fact(DisplayName = "Add_ShouldPublishAddXptoCommand")]
        [Trait("Something - AppService", "Xpto")]
        public async Task Add_ShouldPublishAddXptoCommand()
        {
            // Arrange
            var addXptoDto = new AddXptoDto()
            {
                Name = "Xpto"
            };

            var command = new AddXptoCommand()
            {
                Entity = new Xpto()
                {
                    Name = addXptoDto.Name
                }
            };

            _mockMapper.Setup(e => e.Map<AddXptoCommand>(It.Is<AddXptoDto>(s => s.Equals(addXptoDto)))).Returns(command);

            // Act
            await _xptoAppService.Add(addXptoDto);

            // Assert
            _mockMediatorHandler.Verify(e => e.SendCommand(It.Is<AddXptoCommand>(s => s.Equals(command))), Times.Once);
        }
    }
}
