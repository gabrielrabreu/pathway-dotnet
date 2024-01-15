using Haze.Authentication.Domain.Commands.UserCommands;

namespace Haze.Authentication.Domain.Validators.UserValidators
{
    public class RemoveUserCommandValidator : UserCommandValidator<RemoveUserCommand>
    {
        public RemoveUserCommandValidator()
        {
            IdObrigatorio();
        }
    }
}