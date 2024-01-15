using FluentValidation;
using Haze.Authentication.Domain.Commands.UserCommands;
using Haze.Core.Domain.Common;
using System;

namespace Haze.Authentication.Domain.Validators.UserValidators
{
    public abstract class UserCommandValidator<T> : AbstractValidator<T>
        where T : UserCommand<T>

    {
        protected void UsernameObrigatorio()
        {
            RuleFor(c => c.Entity.Username)
                .NotEmpty()
                .WithMessage(CoreUserMessages.ValorObrigatorioO.Format("Username").Message);
        }

        protected void SenhaObrigatoria()
        {
            RuleFor(c => c.Entity.Password)
                .NotEmpty()
                .WithMessage(CoreUserMessages.ValorObrigatorioO.Format("Password").Message);
        }

        protected void IdObrigatorio()
        {
            RuleFor(c => c.AggregateId)
                .NotEqual(Guid.Empty)
                .WithMessage(CoreUserMessages.ValorObrigatorioO.Format("Id").Message);
        }
    }
}