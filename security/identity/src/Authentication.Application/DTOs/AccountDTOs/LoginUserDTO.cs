namespace Authentication.Application.DTOs.AccountDTOs
{
    public class LoginUserDTO : DTO
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
