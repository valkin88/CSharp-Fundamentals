using System;
using System.Linq;

public class CommandIterator
{
    private ListyIterator<string> listyIterator;

    public void Start()
    {
        string input = Console.ReadLine();
        while (input != "END")
        {
            var inputLine = input.Split(' ').ToArray();

            string command = inputLine[0];
            var commands = inputLine.Skip(1).ToArray();

            switch (command)
            {
                case "Create":
                    listyIterator = new ListyIterator<string>(commands);
                    break;
                case "Move":
                    listyIterator.Move();
                    break;
                case "Print":
                    try
                    {
                        listyIterator.Print();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                    break;
                case "HasNext":
                    listyIterator.HasNext();
                    break;
                default:
                    break;
            }

            input = Console.ReadLine();
        }
    }
}
