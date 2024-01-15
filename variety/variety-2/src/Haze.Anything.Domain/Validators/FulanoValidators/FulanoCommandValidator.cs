using FluentValidation;
using Haze.Anything.Domain.Commands.FulanoCommands;
using Haze.Core.Domain.Common;
using System;

namespace Haze.Anything.Domain.Validators.FulanoValidators
{
    public abstract class FulanoCommandValidator<T> : AbstractValidator<T>
        where T : FulanoCommand<T>

    {
        protected void NomeObrigatorio()
        {
            RuleFor(c => c.Entity.Nome)
                .NotEmpty()
                .WithMessage(CoreUserMessages.ValorObrigatorioO.Format("Nome").Message);
        }

        protected void IdObrigatorio()
        {
            RuleFor(c => c.AggregateId)
                .NotEqual(Guid.Empty)
                .WithMessage(CoreUserMessages.ValorObrigatorioO.Format("Id").Message);
        }
    }
}