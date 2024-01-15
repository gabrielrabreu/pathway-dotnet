using Haze.Anything.Domain.Validators.FulanoValidators;
using System;

namespace Haze.Anything.Domain.Commands.FulanoCommands
{
    public class RemoveFulanoCommand : FulanoCommand<RemoveFulanoCommand>
    {
        public RemoveFulanoCommand(Guid aggregateId)
            : base(aggregateId) { }

        public override bool IsValid()
        {
            ValidationResult = new RemoveFulanoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}