using System;
using System.Linq;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        var type = Assembly.GetCallingAssembly()
            .GetTypes().Single(t => t.Name == difficultyLevel);

        if (type == null)
        {
            throw new ArgumentException("Type not found!");
        }

        if (!typeof(IMission).IsAssignableFrom(type))
        {
            throw new ArgumentException($"{type.Name} is not Assigned to IMission!");
        }

        return (IMission)Activator.CreateInstance(type,
            neededPoints);
    }
}
