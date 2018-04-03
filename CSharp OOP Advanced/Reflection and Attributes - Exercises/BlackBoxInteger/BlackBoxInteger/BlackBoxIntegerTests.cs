namespace BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var blackBoxType = typeof(BlackBoxInteger);
            
            var constructor = blackBoxType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[0], null);
            var classInstance = (BlackBoxInteger)constructor.Invoke(null);

            var input = Console.ReadLine();

            while (input != "END")
            {
                var commandLine = input.Split('_');
                var methodName = commandLine[0];
                var number = int.Parse(commandLine[1]);
                string fieldName = "innerValue";

                ProcessMethod(blackBoxType, classInstance, fieldName, methodName, number);
                
                input = Console.ReadLine();
            }
        }

        private static void ProcessMethod(Type blackBoxType, BlackBoxInteger classInstance, string fieldName, string methodName, int number)
        {
            var method = blackBoxType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);

            method.Invoke(classInstance, new object[] { number });

            PrintFieldValue(blackBoxType, classInstance, fieldName);
        }

        private static void PrintFieldValue(Type blackBoxType, BlackBoxInteger classInstance, string fieldName)
        {
            Console.WriteLine(blackBoxType.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic).GetValue(classInstance));
        }
    }
}
