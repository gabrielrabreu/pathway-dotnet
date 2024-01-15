using Core.Domain.Commands;
using Something.Domain.Entities;
using Something.Domain.Validators.ImportLayoutValidators;
using System;

namespace Something.Domain.Commands.ImportLayoutCommands
{
    public class AddImportLayoutCommand : Command
    {
        public ImportLayout Entity { get; set; }

        public AddImportLayoutCommand() : base(Guid.Empty) { }

        public override bool IsValid()
        {
            ValidationResult = new AddImportLayoutCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
