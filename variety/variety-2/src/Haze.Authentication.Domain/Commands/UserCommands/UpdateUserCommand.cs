using Haze.Authentication.Domain.Validators.UserValidators;
using System;

namespace Haze.Authentication.Domain.Commands.UserCommands
{
    public class UpdateUserCommand : UserCommand<UpdateUserCommand>
    {
        public UpdateUserCommand(Guid aggregateId)
            : base(aggregateId) { }

        public override bool IsValid()
        {
            ValidationResult = new UpdateUserCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}