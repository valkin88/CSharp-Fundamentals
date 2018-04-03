namespace BarraksWars.Core.CommandsPackage
{
    using BarracksFactory.Contracts;
    using BarraksWars.Core.Attributes;

    public class Report : Command
    {
        [Inject]
        private readonly IRepository repository;

        public Report(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            string output = this.repository.Statistics;
            return output;
        }
    }
}
