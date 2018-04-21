using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class RegisterCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public RegisterCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) 
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var entityType = this.Arguments[0];

        var arguments = this.Arguments.Skip(1).ToList();

        var result = String.Empty;

        if (entityType == nameof(Provider))
        {
            result = this.providerController.Register(arguments);
        }
        else if (entityType == nameof(Harvester))
        {
            result = this.harvesterController.Register(arguments);
        }
        
        return result;
    }
}