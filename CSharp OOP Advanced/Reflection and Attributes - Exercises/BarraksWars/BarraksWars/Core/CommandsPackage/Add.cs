﻿namespace BarraksWars.Core.CommandsPackage
{
    using BarracksFactory.Contracts;
    using BarraksWars.Core.Attributes;

    public class Add : Command
    {
        [Inject]
        private readonly IRepository repository;

        [Inject]
        private readonly IUnitFactory unitFactory;

        public Add(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
            this.repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
