﻿namespace BattleCards.ViewModels.Users
{
    public class RegisterInputModel
    {
        public RegisterInputModel()
        {

        }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
