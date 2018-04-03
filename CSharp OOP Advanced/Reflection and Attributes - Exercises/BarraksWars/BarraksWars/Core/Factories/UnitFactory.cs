namespace BarracksFactory.Core.Factories
{
    using System;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type typeOfUnit = Type.GetType($"BarracksFactory.Models.Units.{unitType}");

            var unitConstructor = typeOfUnit.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, new Type[0], null);

            IUnit unit = (IUnit)unitConstructor.Invoke(null);

            return unit;
        }
    }
}
