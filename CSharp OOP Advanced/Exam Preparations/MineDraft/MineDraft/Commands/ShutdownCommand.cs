using System.Collections.Generic;
using System.Text;

public class ShutdownCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public ShutdownCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine(Constants.SystemShutdown);
        builder.AppendLine(string.Format(Constants.TotalEnergyStored, this.providerController.TotalEnergyProduced));
        builder.AppendLine(string.Format(Constants.TotalMinedOres, this.harvesterController.OreProduced));

        return builder.ToString().Trim();
    }
}
