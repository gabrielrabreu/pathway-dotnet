using Haze.Anything.Domain.Commands.FulanoCommands;

namespace Haze.Anything.Domain.Validators.FulanoValidators
{
    public class AddFulanoCommandValidator : FulanoCommandValidator<AddFulanoCommand>
    {
        public AddFulanoCommandValidator()
        {
            NomeObrigatorio();
        }
    }
}