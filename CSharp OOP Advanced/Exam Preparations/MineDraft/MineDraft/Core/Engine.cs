using System.Linq;

public class Engine
{
    private ICommandInterpreter commandInterpreter;
    private IReader reader;
    private IWriter writer;

    public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        while (true)
        {
            var inputArgs = reader.ReadLine().Split().ToList();

            string result = commandInterpreter.ProcessCommand(inputArgs);

            writer.WriteLine(result);

            if (inputArgs[0] == Constants.EndProgram)
            {
                break;
            }
        }
    }
}
