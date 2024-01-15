using Core.Domain.Common;
using Core.Domain.Validators;
using FluentValidation;
using Something.Domain.Commands.ImportCommands;

namespace Something.Domain.Validators.ImportValidators
{
    public class AddImportCommandValidator : CommandValidator<AddImportCommand>
    {
        public AddImportCommandValidator()
        {
            RuleFor(x => x.Entity.ImportLayoutId)
                .NotEmpty()
                .WithMessage(DomainMessages.RequiredField.Format("ImportLayoutId").Message);

            RuleFor(x => x.Entity.ImportItems)
                .NotEmpty()
                .WithMessage(DomainMessages.RequiredField.Format("ImportItems").Message);
        }
    }
}
