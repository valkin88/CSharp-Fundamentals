namespace BarraksWars.Core.CommandsPackage
{
    using BarracksFactory.Contracts;
    using BarraksWars.Core.Attributes;

    public class Retire : Command
    {
        [Inject]
        private readonly IRepository repository;

        public Retire(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            this.repository.RemoveUnit(unitType);

            return $"{unitType} retired!";
        }
    }
}
