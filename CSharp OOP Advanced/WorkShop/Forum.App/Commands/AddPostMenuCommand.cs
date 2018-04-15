using Forum.App.Contracts;
using System;
using System.Collections.Generic;
namespace Forum.App.Commands
{
    public class AddPostMenuCommand : NavigationMenuCommand
    {
        public AddPostMenuCommand(IMenuFactory menuFactory) 
            : base(menuFactory)
        {
        }
    }
}
