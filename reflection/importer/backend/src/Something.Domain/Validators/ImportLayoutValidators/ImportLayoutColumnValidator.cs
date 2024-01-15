using Core.Domain.Common;
using FluentValidation;
using Something.Domain.Entities;

namespace Something.Domain.Validators.ImportLayoutValidators
{
    public class ImportLayoutColumnValidator : AbstractValidator<ImportLayoutColumn>
    {
        public ImportLayoutColumnValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(DomainMessages.RequiredField.Format("Name").Message);

            RuleFor(x => x.Position)
                .GreaterThanOrEqualTo(1)
                .WithMessage(DomainMessages.MustBeGreatherOrEqual.Format("Position", 1).Message);
        }
    }
}
