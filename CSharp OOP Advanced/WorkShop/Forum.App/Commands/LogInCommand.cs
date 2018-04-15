﻿namespace Forum.App.Commands
{
    using Forum.App.Contracts;
    using System;

    public class LogInCommand : ICommand
    {
        private IUserService userService;
        private IMenuFactory menuFactory;

        public LogInCommand(IUserService userService, IMenuFactory menuFactory)
        {
            this.userService = userService;
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            string username = args[0];
            string password = args[1];

            bool validUsername = !string.IsNullOrWhiteSpace(username) && username.Length >= 4;
            bool validPassword = !string.IsNullOrWhiteSpace(password) && password.Length >= 4;

            if (!validUsername || !validPassword)
            {
                throw new ArgumentException("Invalid Username or Password!");
            }

            bool success = this.userService.TryLogInUser(username, password);

            if (!success)
            {
                throw new InvalidOperationException("Invalid login!");
            }

            return this.menuFactory.CreateMenu("MainMenu");
        }
    }
}
