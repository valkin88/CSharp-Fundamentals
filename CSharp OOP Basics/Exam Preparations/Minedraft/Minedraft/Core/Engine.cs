using System;
using System.Linq;

public class Engine
{
    private DraftManager draftManager;

    public Engine()
    {
        this.draftManager = new DraftManager();
    }

    public void Run()
    {
        string input;

        while ((input = Console.ReadLine()) != "Shutdown")
        {
            var commands = input.Split().ToList();
            var command = commands[0];
            commands.RemoveAt(0);

            switch (command)
            {
                case "RegisterHarvester":
                    Console.WriteLine(this.draftManager.RegisterHarvester(commands));
                    break;
                case "RegisterProvider":
                    Console.WriteLine(this.draftManager.RegisterProvider(commands));
                    break;
                case "Day":
                    Console.WriteLine(this.draftManager.Day());
                    break;
                case "Mode":
                    Console.WriteLine(this.draftManager.Mode(commands));
                    break;
                case "Check":
                    Console.WriteLine(this.draftManager.Check(commands));
                    break;
            }
        }
        Console.WriteLine(this.draftManager.ShutDown());
    }
}
