using Haze.Authentication.Domain.Commands.UserCommands;

namespace Haze.Authentication.Domain.Validators.UserValidators
{
    public class UpdateUserCommandValidator : UserCommandValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            IdObrigatorio();
            UsernameObrigatorio();
            SenhaObrigatoria();
        }
    }
}