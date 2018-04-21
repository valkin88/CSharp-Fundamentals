using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class MyTests
{
    private EnergyRepository energyRepository;
    private ProviderController providerController;

    [SetUp]
    public void SetUpProviderControler()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(energyRepository);
    }

    [Test]
    public void ProducesCorrectAmountOfEnergy()
    {
        List<string> firstProviderArgs = new List<string>
        {
            "Solar", "1", "100"
        };

        List<string> secondProviderArgs = new List<string>
        {
            "Solar", "1", "100"
        };

        this.providerController.Register(firstProviderArgs);
        this.providerController.Register(secondProviderArgs);

        for (int i = 0; i < 3; i++)
        {
            this.providerController.Produce();
        }

        Assert.That(this.providerController.TotalEnergyProduced, Is.EqualTo(600));
    }

    [Test]
    public void BrokenProviderIsDeleted()
    {
        List<string> firstProviderArgs = new List<string>
        {
            "Pressure", "1", "100"
        };

        this.providerController.Register(firstProviderArgs);

        for (int i = 0; i < 8; i++)
        {
            this.providerController.Produce();
        }

        Assert.That(this.providerController.Entities.Count, Is.EqualTo(0));
    }
}
