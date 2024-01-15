using Haze.Anything.Domain.Validators.FulanoValidators;
using System;

namespace Haze.Anything.Domain.Commands.FulanoCommands
{
    public class AddFulanoCommand : FulanoCommand<AddFulanoCommand>
    {
        public AddFulanoCommand()
            : base(Guid.Empty) { }

        public override bool IsValid()
        {
            ValidationResult = new AddFulanoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}