namespace InfernoInfinity.Core.Commands
{
    using System;

    public class End : Command
    {
        public End(string[] data) : base(data)
        {
        }

        public override void Execute()
        {
            Environment.Exit(0);
        }
    }
}
