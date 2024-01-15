using Core.Domain.Commands;
using Something.Domain.Entities;
using Something.Domain.Validators.XptoValidators;
using System;

namespace Something.Domain.Commands.XptoCommands
{
    public class AddXptoCommand : Command
    {
        public Xpto Entity { get; set; }

        public AddXptoCommand() : base(Guid.Empty) { }

        public override bool IsValid()
        {
            ValidationResult = new AddXptoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
