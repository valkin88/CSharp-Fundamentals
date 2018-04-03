namespace BarracksFactory.Core
{
    using System;
    using BarraksWars.Core.Attributes;
    using System.Linq;
    using System.Reflection;
    using BarraksWars.Core.CommandsPackage;
    using Contracts;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];

                    IExecutable command = GetCommand(data, commandName);
                    string result = command.Execute();

                    if (result == "end")
                    {
                        Environment.Exit(0);
                    }

                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private IExecutable GetCommand(string[] data, string commandName)
        {
            Type commandType = GetTypesOfCommands(commandName);

            object[] parameters = new object[] { data };

            IExecutable command = (Command)Activator.CreateInstance(commandType, parameters);

            FieldInfo[] commandFieldInfos = commandType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo[] engineFieldInfos = typeof(Engine).GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            SetFields(command, commandFieldInfos, engineFieldInfos);

            return command;
        }

        private void SetFields(IExecutable command, FieldInfo[] commandFieldInfos, FieldInfo[] engineFieldInfos)
        {
            foreach (var fieldinfo in commandFieldInfos)
            {
                if (engineFieldInfos.Any(f => f.FieldType == fieldinfo.FieldType))
                {
                    fieldinfo.SetValue(command, engineFieldInfos.First(f => f.FieldType == fieldinfo.FieldType).GetValue(this));
                }
            }
        }

        private Type GetTypesOfCommands(string commandName)
        {
            foreach (Type type in Assembly.GetAssembly(typeof(Command)).GetTypes().Where(c => c.IsClass && !c.IsAbstract && c.IsSubclassOf(typeof(Command))))
            {
                string typeToString = type.ToString().ToLower();
                string typeToCompare = $"barrakswars.core.commandspackage.{commandName}";

                if (typeToString == typeToCompare)
                {
                    return type;
                }
            }

            throw new InvalidOperationException("Invalid command!");
        }
    }
}
