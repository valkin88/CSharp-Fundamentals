namespace BarraksWars.Core.CommandsPackage
{
    public class Fight : Command
    {
        public Fight(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            return "end";
        }
    }
}
