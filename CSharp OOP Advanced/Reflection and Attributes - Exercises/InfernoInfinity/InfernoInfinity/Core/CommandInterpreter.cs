namespace InfernoInfinity.Core
{
    using InfernoInfinity.Contracts;
    using InfernoInfinity.Core.Commands;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private List<IWeapon> createdWeapons;
        private IWeaponStorage weaponStorage;
        private IWeaponFactory weaponFactory;
        private IGemFactory gemFactory;

        public CommandInterpreter(List<IWeapon> createdWeapons, IWeaponStorage weaponStorage, IWeaponFactory weaponFactory, IGemFactory gemFactory)
        {
            this.createdWeapons = createdWeapons;
            this.weaponStorage = weaponStorage;
            this.weaponFactory = weaponFactory;
            this.gemFactory = gemFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Type commandType = GetTypesOfCommands(commandName);
            
            object[] parameters = new object[] { data };
            
            IExecutable command = (Command)Activator.CreateInstance(commandType, parameters);
            
            FieldInfo[] commandFieldInfos = commandType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo[] interpreterFieldInfos = typeof(CommandInterpreter).GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            
            SetFields(command, commandFieldInfos, interpreterFieldInfos);
            
            return command;
            
        }

        private Type GetTypesOfCommands(string commandName)
        {
            foreach (Type type in Assembly.GetAssembly(typeof(Command)).GetTypes().Where(c => c.IsClass && !c.IsAbstract && c.IsSubclassOf(typeof(Command))))
            {
                string typeToString = type.ToString().ToLower();
                string typeToCompare = $"infernoinfinity.core.commands.{commandName.ToLower()}";

                if (typeToString == typeToCompare)
                {
                    return type;
                }
            }

            throw new InvalidOperationException("Invalid command!");
        }

        private void SetFields(IExecutable command, FieldInfo[] commandFieldInfos, FieldInfo[] interpreterFieldInfos)
        {
            foreach (var fieldinfo in commandFieldInfos)
            {
                if (interpreterFieldInfos.Any(f => f.FieldType == fieldinfo.FieldType))
                {
                    fieldinfo.SetValue(command, interpreterFieldInfos.First(f => f.FieldType == fieldinfo.FieldType).GetValue(this));
                }
            }
        }
    }
}
