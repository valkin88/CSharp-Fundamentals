namespace InfernoInfinity.Core
{
    using InfernoInfinity.Contracts;
    using InfernoInfinity.Core.Factories;
    using System;
    using System.Collections.Generic;

    public class Engine : IRunnable
    {
        private ICommandInterpreter commandInterpreter;
        private List<IWeapon> createdWeapons;
        private IWeaponStorage weaponStorage;
        private IWeaponFactory weaponFactory;
        private IGemFactory gemFactory;

        public Engine()
        {
            this.createdWeapons = new List<IWeapon>();
            this.weaponStorage = new WeaponStorage();
            this.weaponFactory = new WeaponFactory();
            this.gemFactory = new GemFactory();
            this.commandInterpreter = new CommandInterpreter(createdWeapons, weaponStorage, weaponFactory, gemFactory);
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string[] data = Console.ReadLine().Split(';');
                    string commandName = data[0];

                    IExecutable command = commandInterpreter.InterpretCommand(data, commandName);

                    command.Execute();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
