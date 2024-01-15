using Core.Domain.Commands;
using Something.Domain.Entities;
using Something.Domain.Validators.ImportValidators;
using System;

namespace Something.Domain.Commands.ImportCommands
{
    public class AddImportCommand : Command
    {
        public Import Entity { get; set; }

        public AddImportCommand() : base(Guid.Empty) { }

        public override bool IsValid()
        {
            ValidationResult = new AddImportCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
