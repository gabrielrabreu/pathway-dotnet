using Haze.Authentication.Domain.Validators.UserValidators;
using System;

namespace Haze.Authentication.Domain.Commands.UserCommands
{
    public class RemoveUserCommand : UserCommand<RemoveUserCommand>
    {
        public RemoveUserCommand(Guid aggregateId)
            : base(aggregateId) { }

        public override bool IsValid()
        {
            ValidationResult = new RemoveUserCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}