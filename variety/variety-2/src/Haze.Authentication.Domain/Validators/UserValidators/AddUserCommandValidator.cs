using Haze.Authentication.Domain.Commands.UserCommands;

namespace Haze.Authentication.Domain.Validators.UserValidators
{
    public class AddUserCommandValidator : UserCommandValidator<AddUserCommand>
    {
        public AddUserCommandValidator()
        {
            UsernameObrigatorio();
            SenhaObrigatoria();
        }
    }
}