namespace Forum.App.Commands
{
    using Forum.App.Contracts;

    public class LogInMenuCommand : NavigationMenuCommand
    {
        public LogInMenuCommand(IMenuFactory menuFactory) 
            : base(menuFactory)
        {
        }
    }
}
