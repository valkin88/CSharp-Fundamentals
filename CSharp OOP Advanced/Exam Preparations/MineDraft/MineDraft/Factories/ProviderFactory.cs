﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class ProviderFactory : IProviderFactory
{
    public IProvider GenerateProvider(IList<string> args)
    {
        int id = int.Parse(args[1]);
        string type = args[0];
        double energyOutput = double.Parse(args[2]);

        Type providerType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type + "Provider");

        if (providerType == null)
        {
            throw new ArgumentException("No Provider Found!");
        }

        if (!typeof(IProvider).IsAssignableFrom(providerType))
        {
            throw new ArgumentException("The type is not Assignate to IProvider!");
        }

        var ctors = providerType.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        IProvider provider = (IProvider)ctors[0].Invoke(new object[] { id, energyOutput });

        return provider;
    }
}