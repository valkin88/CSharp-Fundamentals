using System;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {
        Stack<string> stack = new Stack<string>();

        while (true)
        {
            string[] inputCommands = Console.ReadLine().Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);
            string command = inputCommands[0];

            switch (command)
            {
                case "Push":
                    stack.Push(inputCommands.Skip(1).ToArray());
                    break;
                case "Pop":
                    try
                    {
                        stack.Pop();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                default:
                    break;
            }

            if (command == "END")
            {
                if (stack.Count() == 0)
                {
                    break;
                }
                Console.WriteLine(stack);
                break;
            }
        }
    }
}
