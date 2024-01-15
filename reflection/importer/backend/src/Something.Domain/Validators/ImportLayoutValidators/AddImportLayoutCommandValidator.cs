using Core.Domain.Common;
using Core.Domain.Validators;
using FluentValidation;
using Something.Domain.Commands.ImportLayoutCommands;

namespace Something.Domain.Validators.ImportLayoutValidators
{
    public class AddImportLayoutCommandValidator : CommandValidator<AddImportLayoutCommand>
    {
        public AddImportLayoutCommandValidator()
        {
            RuleFor(x => x.Entity.Name)
                .NotEmpty()
                .WithMessage(DomainMessages.RequiredField.Format("Name").Message);

            RuleFor(x => x.Entity.Separator)
                .NotEmpty()
                .WithMessage(DomainMessages.RequiredField.Format("Separator").Message);

            RuleFor(x => x.Entity.Service)
                .IsInEnum()
                .WithMessage(DomainMessages.InvalidFormat.Format("Service").Message)
                .NotEmpty()
                .WithMessage(DomainMessages.RequiredField.Format("Service").Message);

            RuleFor(x => x.Entity.Columns)
                .NotEmpty()
                .WithMessage(DomainMessages.RequiredField.Format("ImportLayoutColumns").Message);

            RuleForEach(x => x.Entity.Columns).SetValidator(new ImportLayoutColumnValidator());
        }
    }
}
