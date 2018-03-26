using System;
using System.Linq;

public class Engine
{
    CustomList<string> customList = new CustomList<string>();

    public Engine()
    {
        this.customList = new CustomList<string>();
    }

    public void Start()
    {
        var input = Console.ReadLine();

        while (input != "END")
        {
            var inputCommands = input.Split(' ').ToArray();
            var command = inputCommands[0];
            var value = "";

            switch (command)
            {
                case "Add":
                    value = inputCommands[1];
                    this.customList.Add(value);
                    break;
                case "Remove":
                    var index = int.Parse(inputCommands[1]);
                    this.customList.Remove(index);
                    break;
                case "Contains":
                    value = inputCommands[1];
                    Console.WriteLine(this.customList.Contains(value));
                    break;
                case "Swap":
                    var firstIndex = int.Parse(inputCommands[1]);
                    var secondIndex = int.Parse(inputCommands[2]);
                    this.customList.Swap(firstIndex, secondIndex);
                    break;
                case "Greater":
                    value = inputCommands[1];
                    int greaterValue = this.customList.CountGreaterThan(value);
                    Console.WriteLine(greaterValue);
                    break;
                case "Max":
                    Console.WriteLine(this.customList.Max());
                    break;
                case "Min":
                    Console.WriteLine(this.customList.Min());
                    break;
                case "Sort":
                    this.customList.Sort();
                    break;
                case "Print":
                    Console.WriteLine(this.customList.ToString());
                    break;
                default:
                    break;
            }

            input = Console.ReadLine();
        }
    }
}