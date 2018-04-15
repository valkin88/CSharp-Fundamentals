namespace Forum.App.Commands
{
    using Forum.App.Contracts;

    public class SignUpMenuCommand : NavigationMenuCommand
    {
        public SignUpMenuCommand(IMenuFactory menuFactory) 
            : base(menuFactory)
        {
        }
    }
}
