using Something.Domain.CommandHandlers;
using Something.Domain.Commands.XptoCommands;
using Core.Domain.Common;
using Core.Domain.Interfaces;
using Core.Domain.Mediator;
using Core.Domain.Notifications;
using Something.Domain.Entities;
using Something.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Something.Domain.Tests.CommandHandlers
{
    public class XptoCommandHandlerTests
    {
        private readonly Mock<IMediatorHandler> _mockMediatorHandler;
        private readonly Mock<IXptoRepository> _mockXptoRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly XptoCommandHandler _xptoCommandHandler;

        public XptoCommandHandlerTests()
        {
            _mockMediatorHandler = new Mock<IMediatorHandler>();
            _mockXptoRepository = new Mock<IXptoRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _xptoCommandHandler = new XptoCommandHandler(
                _mockMediatorHandler.Object,
                new Mock<DomainNotificationHandler>().Object,
                _mockXptoRepository.Object);
        }

        [Fact(DisplayName = "Handle_AddXptoCommand_ShouldPublishDomainNotification_WhenInvalidCommand")]
        [Trait("Something - CommandHandler", "Xpto")]
        public async Task Handle_AddXptoCommand_ShouldPublishDomainNotification_WhenInvalidCommand()
        {
            // Arrange
            var command = new AddXptoCommand()
            {
                Entity = new Xpto()
                {
                    Name = ""
                }
            };

            // Act
            await _xptoCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            _mockMediatorHandler.Verify(e => e.PublishDomainNotification(It.Is<DomainNotification>(s => 
                s.Key == command.MessageType && s.Value == DomainMessages.RequiredField.Format("Name").Message)), Times.Once);
        }

        [Fact(DisplayName = "Handle_AddXptoCommand_ShouldPublishDomainNotification_WhenNameAlreadyInUse")]
        [Trait("Something - CommandHandler", "Xpto")]
        public async Task Handle_AddXptoCommand_ShouldPublishDomainNotification_WhenNameAlreadyInUse()
        {
            // Arrange
            var command = new AddXptoCommand()
            {
                Entity = new Xpto()
                {
                    Name = "Xpto",
                    Version = 1,
                    Value = 1.0,
                    Date = DateTime.UtcNow
                }
            };

            _mockXptoRepository.Setup(e => e.Search(It.IsAny<Expression<Func<Xpto, bool>>>()))
                .ReturnsAsync(new List<Xpto>() { new Xpto() { Name = command.Entity.Name } });

            // Act
            await _xptoCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            _mockMediatorHandler.Verify(e => e.PublishDomainNotification(It.Is<DomainNotification>(s => 
                s.Key == command.MessageType && s.Value == DomainMessages.AlreadyInUse.Format("Name").Message)), Times.Once);
        }

        [Fact(DisplayName = "Handle_AddXptoCommand_ShouldAddAndCommit_WhenValid")]
        [Trait("Something - CommandHandler", "Xpto")]
        public async Task Handle_AddXptoCommand_ShouldAddAndCommit_WhenValid()
        {
            // Arrange
            var command = new AddXptoCommand()
            {
                Entity = new Xpto()
                {
                    Name = "Xpto",
                    Version = 1,
                    Value = 1.0,
                    Date = DateTime.UtcNow
                }
            };

            _mockXptoRepository.Setup(e => e.Search(It.IsAny<Expression<Func<Xpto, bool>>>())).ReturnsAsync(new List<Xpto>());
            _mockUnitOfWork.Setup(e => e.Commit()).ReturnsAsync(true);
            _mockXptoRepository.SetupGet(e => e.UnitOfWork).Returns(_mockUnitOfWork.Object);

            // Act
            await _xptoCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            _mockXptoRepository.Verify(e => e.Add(It.Is<Xpto>(s => s.Equals(command.Entity))), Times.Once);
            _mockUnitOfWork.Verify(e => e.Commit(), Times.Once);
            _mockMediatorHandler.Verify(e => e.PublishDomainNotification(It.IsAny<DomainNotification>()), Times.Never);
        }
    }
}
