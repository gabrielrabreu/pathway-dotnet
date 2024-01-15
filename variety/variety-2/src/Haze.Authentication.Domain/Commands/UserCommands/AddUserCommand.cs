using Haze.Authentication.Domain.Validators.UserValidators;
using System;

namespace Haze.Authentication.Domain.Commands.UserCommands
{
    public class AddUserCommand : UserCommand<AddUserCommand>
    {
        public AddUserCommand()
            : base(Guid.Empty) { }

        public override bool IsValid()
        {
            ValidationResult = new AddUserCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}