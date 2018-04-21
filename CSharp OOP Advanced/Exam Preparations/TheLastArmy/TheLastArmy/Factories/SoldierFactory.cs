using System;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        var type = Assembly.GetCallingAssembly().GetTypes().Single(t => t.Name == soldierTypeName);

        if (type == null)
        {
            throw new ArgumentException("Type not found!");
        }

        if (!typeof(ISoldier).IsAssignableFrom(type))
        {
            throw new ArgumentException($"{type.Name} is not Assigned to ISoldier!");
        }

        return (ISoldier)Activator.CreateInstance(type,
            name, age, experience, endurance);
    }
}