using Haze.Anything.Domain.Commands.FulanoCommands;

namespace Haze.Anything.Domain.Validators.FulanoValidators
{
    public class UpdateFulanoCommandValidator : FulanoCommandValidator<UpdateFulanoCommand>
    {
        public UpdateFulanoCommandValidator()
        {
            IdObrigatorio();
            NomeObrigatorio();
        }
    }
}