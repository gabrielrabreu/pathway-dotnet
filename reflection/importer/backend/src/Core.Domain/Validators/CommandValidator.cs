using FluentValidation;
using Core.Domain.Commands;

namespace Core.Domain.Validators
{
    public abstract class CommandValidator<T> : AbstractValidator<T> where T : Command
    {
        protected CommandValidator() { }
    }
}
