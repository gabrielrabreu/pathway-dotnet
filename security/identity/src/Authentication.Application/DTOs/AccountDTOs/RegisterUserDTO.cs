﻿namespace Authentication.Application.DTOs.AccountDTOs
{
    public class RegisterUserDTO : DTO
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
