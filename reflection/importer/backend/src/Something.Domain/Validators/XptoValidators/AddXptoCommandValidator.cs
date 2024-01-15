using FluentValidation;
using Something.Domain.Commands.XptoCommands;
using Core.Domain.Common;
using Core.Domain.Validators;

namespace Something.Domain.Validators.XptoValidators
{
    public class AddXptoCommandValidator : CommandValidator<AddXptoCommand>
    {
        public AddXptoCommandValidator()
        {
            RuleFor(x => x.Entity.Name)
                .NotEmpty()
                .WithMessage(DomainMessages.RequiredField.Format("Name").Message);

            RuleFor(x => x.Entity.Date)
                .NotEmpty()
                .WithMessage(DomainMessages.RequiredField.Format("Date").Message);

            RuleFor(x => x.Entity.Version)
                .GreaterThanOrEqualTo(1)
                .WithMessage(DomainMessages.MustBeGreatherOrEqual.Format("Version", 1).Message);

            RuleFor(x => x.Entity.Value)
                .GreaterThanOrEqualTo(0)
                .WithMessage(DomainMessages.MustBeGreatherOrEqual.Format("Value", 0).Message);
        }
    }
}
