using Something.Domain.Commands.XptoCommands;
using Core.Domain.Common;
using Something.Domain.Entities;
using System.Linq;
using Xunit;
using System;

namespace Something.Domain.Tests.Commands
{
    public class XptoCommandTests
    {
        [Fact(DisplayName = "AddXptoCommand_ShouldFailValidation_WhenEmptyName")]
        [Trait("Something - Command", "Xpto")]
        public void AddXptoCommand_ShouldFailValidation_WhenEmptyName()
        {
            // Arrange
            var command = new AddXptoCommand()
            {
                Entity = new Xpto()
                {
                    Name = "",
                    Version = 1,
                    Value = 1.0,
                    Date = DateTime.UtcNow
                }
            };

            // Act
            command.IsValid();

            // Assert
            Assert.Equal(DomainMessages.RequiredField.Format("Name").Message, 
                command.ValidationResult.Errors.Single().ErrorMessage);
        }

        [Fact(DisplayName = "AddXptoCommand_ShouldFailValidation_WhenVersionLessThanOne")]
        [Trait("Something - Command", "Xpto")]
        public void AddXptoCommand_ShouldFailValidation_WhenVersionLessThanOne()
        {
            // Arrange
            var command = new AddXptoCommand()
            {
                Entity = new Xpto()
                {
                    Name = "Xpto",
                    Version = 0,
                    Value = 1.0,
                    Date = DateTime.UtcNow
                }
            };

            // Act
            command.IsValid();

            // Assert
            Assert.Equal(DomainMessages.MustBeGreatherOrEqual.Format("Version", 1).Message,
                command.ValidationResult.Errors.Single().ErrorMessage);
        }

        [Fact(DisplayName = "AddXptoCommand_ShouldFailValidation_WhenValueLessThanZero")]
        [Trait("Something - Command", "Xpto")]
        public void AddXptoCommand_ShouldFailValidation_WhenValueLessThanZero()
        {
            // Arrange
            var command = new AddXptoCommand()
            {
                Entity = new Xpto()
                {
                    Name = "Xpto",
                    Version = 1,
                    Value = -1.0,
                    Date = DateTime.UtcNow
                }
            };

            // Act
            command.IsValid();

            // Assert
            Assert.Equal(DomainMessages.MustBeGreatherOrEqual.Format("Value", 0).Message,
                command.ValidationResult.Errors.Single().ErrorMessage);
        }

        [Fact(DisplayName = "AddXptoCommand_ShouldFailValidation_WhenEmptyDate")]
        [Trait("Something - Command", "Xpto")]
        public void AddXptoCommand_ShouldFailValidation_WhenEmptyDate()
        {
            // Arrange
            var command = new AddXptoCommand()
            {
                Entity = new Xpto()
                {
                    Name = "Xpto",
                    Version = 1,
                    Value = 1.0,
                    Date = DateTime.MinValue
                }
            };

            // Act
            command.IsValid();

            // Assert
            Assert.Equal(DomainMessages.RequiredField.Format("Date").Message,
                command.ValidationResult.Errors.Single().ErrorMessage);
        }

        [Fact(DisplayName = "AddXptoCommand_ShouldBeValid_WhenBeWithinValidationRules")]
        [Trait("Something - Command", "Xpto")]
        public void AddXptoCommand_ShouldBeValid_WhenBeWithinValidationRules()
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

            // Act
            command.IsValid();

            // Assert
            Assert.True(command.ValidationResult.IsValid);
            Assert.Empty(command.ValidationResult.Errors);
        }
    }
}
