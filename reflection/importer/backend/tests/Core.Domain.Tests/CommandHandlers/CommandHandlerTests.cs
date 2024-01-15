using FluentValidation.Results;
using Core.Domain.CommandHandlers;
using Core.Domain.Commands;
using Core.Domain.Common;
using Core.Domain.Interfaces;
using Core.Domain.Mediator;
using Core.Domain.Notifications;
using MediatR;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Core.Domain.Tests.CommandHandlers
{
    public class CommandHandlerTests
    {
        private readonly Mock<IMediatorHandler> _mockMediatorHandler;
        private readonly Mock<DomainNotificationHandler> _mockNotifications;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly MyCommandHandlerConcreteClass _myCommandHandlerConcreteClass;

        public CommandHandlerTests()
        {
            _mockMediatorHandler = new Mock<IMediatorHandler>();
            _mockNotifications = new Mock<DomainNotificationHandler>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _myCommandHandlerConcreteClass = new MyCommandHandlerConcreteClass(
                _mockMediatorHandler.Object,
                _mockNotifications.Object);
        }

        [Fact(DisplayName = "Commit_ShouldPublishDomainNotification_WhenAlreadyHaveAnotherNotification")]
        [Trait("Core - CommandHandler", "CommandHandler")]
        public async Task Commit_ShouldPublishDomainNotification_WhenAlreadyHaveAnotherNotification()
        {
            // Arrange
            _mockNotifications.Setup(e => e.HasNotifications()).Returns(true);

            // Act
            var result = await _myCommandHandlerConcreteClass.TestCommit(_mockUnitOfWork.Object);

            // Assert
            _mockMediatorHandler.Verify(e => e.PublishDomainNotification(It.Is<DomainNotification>(s => 
                s.Key == "Commit" && s.Value == DomainMessages.CommitFailed.Message)), Times.Once);
            Assert.False(result);
        }

        [Fact(DisplayName = "Commit_ShouldReturnTrue_WhenCommitWorks")]
        [Trait("Core - CommandHandler", "CommandHandler")]
        public async Task Commit_ShouldReturnTrue_WhenCommitWorks()
        {
            // Arrange
            _mockNotifications.Setup(e => e.HasNotifications()).Returns(false);
            _mockUnitOfWork.Setup(e => e.Commit()).ReturnsAsync(true);

            // Act
            var result = await _myCommandHandlerConcreteClass.TestCommit(_mockUnitOfWork.Object);

            // Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Commit_ShouldPublishDomainNotification_WhenCommitFailed")]
        [Trait("Core - CommandHandler", "CommandHandler")]
        public async Task Commit_ShouldPublishDomainNotification_WhenCommitFailed()
        {
            // Arrange
            _mockNotifications.Setup(e => e.HasNotifications()).Returns(false);
            _mockUnitOfWork.Setup(e => e.Commit()).ReturnsAsync(false);

            // Act
            var result = await _myCommandHandlerConcreteClass.TestCommit(_mockUnitOfWork.Object);

            // Assert
            _mockMediatorHandler.Verify(e => e.PublishDomainNotification(It.Is<DomainNotification>(s =>
                s.Key == "Commit" && s.Value == DomainMessages.CommitFailed.Message)), Times.Once);
            Assert.False(result);
        }

        [Fact(DisplayName = "PublishValidationErrors_ShouldDoNothing_WhenCommandDontHaveValidationErrors")]
        [Trait("Core - CommandHandler", "CommandHandler")]
        public async Task PublishValidationErrors_ShouldDoNothing_WhenCommandDontHaveValidationErrors()
        {
            // Arrange
            var command = new Mock<Command>(Guid.NewGuid());
            command.SetupGet(e => e.ValidationResult).Returns(new ValidationResult());

            // Act
            await _myCommandHandlerConcreteClass.TestPublishValidationErrors(command.Object);

            // Assert
            _mockMediatorHandler.Verify(e => e.PublishDomainNotification(It.IsAny<DomainNotification>()), Times.Never);
        }

        [Fact(DisplayName = "PublishValidationErrors_ShouldPublishDomainNotification_WhenCommandHaveValidationErrors")]
        [Trait("Core - CommandHandler", "CommandHandler")]
        public async Task PublishValidationErrors_ShouldPublishDomainNotification_WhenCommandHaveValidationErrors()
        {
            // Arrange
            var validationResult = new ValidationResult();
            validationResult.Errors.Add(new ValidationFailure("PropertyNameOne", "ErrorMessageOne"));
            validationResult.Errors.Add(new ValidationFailure("PropertyNameTwo", "ErrorMessageTwo"));
            var command = new Mock<Command>(Guid.NewGuid());
            command.SetupGet(e => e.ValidationResult).Returns(validationResult);

            // Act
            await _myCommandHandlerConcreteClass.TestPublishValidationErrors(command.Object);

            // Assert
            _mockMediatorHandler.Verify(e => e.PublishDomainNotification(It.Is<DomainNotification>(s =>
                s.Key == "CommandProxy" && s.Value == "ErrorMessageOne")), Times.Once);
            _mockMediatorHandler.Verify(e => e.PublishDomainNotification(It.Is<DomainNotification>(s =>
                s.Key == "CommandProxy" && s.Value == "ErrorMessageTwo")), Times.Once);
        }
    }

    public class MyCommandHandlerConcreteClass : CommandHandler
    {
        public MyCommandHandlerConcreteClass(IMediatorHandler mediatorHandler,
                                             INotificationHandler<DomainNotification> notifications)
            : base(mediatorHandler, notifications) { }

        public async Task<bool> TestCommit(IUnitOfWork uow)
        {
            return await Commit(uow);
        }

        public async Task TestPublishValidationErrors(Command command)
        {
            await PublishValidationErrors(command);
        }
    }
}
