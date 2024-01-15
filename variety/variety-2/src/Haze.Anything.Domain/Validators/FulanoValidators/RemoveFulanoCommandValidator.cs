using Haze.Anything.Domain.Commands.FulanoCommands;

namespace Haze.Anything.Domain.Validators.FulanoValidators
{
    public class RemoveFulanoCommandValidator : FulanoCommandValidator<RemoveFulanoCommand>
    {
        public RemoveFulanoCommandValidator()
        {
            IdObrigatorio();
        }
    }
}