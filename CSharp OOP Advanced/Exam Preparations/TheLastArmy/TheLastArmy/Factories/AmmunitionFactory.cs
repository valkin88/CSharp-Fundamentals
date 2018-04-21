using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        var type = Assembly.GetCallingAssembly().GetTypes().Single(t => t.Name == ammunitionName);

        if (type == null)
        {
            throw new ArgumentException("Type not found!");
        }

        if (!typeof(IAmmunition).IsAssignableFrom(type))
        {
            throw new ArgumentException($"{type.Name} is not Assigned to IAmmunition!");
        }

        return (IAmmunition)Activator.CreateInstance(type);
    }
}