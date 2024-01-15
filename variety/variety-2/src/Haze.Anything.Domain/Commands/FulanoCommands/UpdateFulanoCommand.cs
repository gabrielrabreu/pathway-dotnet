using Haze.Anything.Domain.Validators.FulanoValidators;
using System;

namespace Haze.Anything.Domain.Commands.FulanoCommands
{
    public class UpdateFulanoCommand : FulanoCommand<UpdateFulanoCommand>
    {
        public UpdateFulanoCommand(Guid aggregateId)
            : base(aggregateId) { }

        public override bool IsValid()
        {
            ValidationResult = new UpdateFulanoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}