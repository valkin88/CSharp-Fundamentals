namespace StorageMaster.Core
{
    using System;
    using System.Linq;
    using global::StorageMaster.Constants;

    public class Engine
    {
        private StorageMaster storageMaster;

        public Engine()
        {
            this.storageMaster = new StorageMaster();
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                try
                {
                    string[] commandArgs = input.Split();

                    string command = commandArgs[0];

                    string output = ExecuteCommand(command, commandArgs.Skip(1).ToArray());

                    Console.WriteLine(output);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(string.Format(Constants.ErrorMessage, ex.Message));
                }
                
            }

            string finalResult = this.storageMaster.GetSummary();

            Console.WriteLine(finalResult);
        }

        private string ExecuteCommand(string command, string[] commandArgs)
        {
            string result = String.Empty;

            switch (command)
            {
                case "AddProduct":

                    string typeOfProduct = commandArgs[0];
                    double priceOfProduct = double.Parse(commandArgs[1]);
                    result = this.storageMaster.AddProduct(typeOfProduct, priceOfProduct);

                    break;
                case "RegisterStorage":

                    string typeOfStorage = commandArgs[0];
                    string nameOfStorage = commandArgs[1];
                    result = this.storageMaster.RegisterStorage(typeOfStorage, nameOfStorage);

                    break;
                case "SelectVehicle":

                    string storageName = commandArgs[0];
                    int garageSlot = int.Parse(commandArgs[1]);
                    result = this.storageMaster.SelectVehicle(storageName, garageSlot);

                    break;
                case "LoadVehicle":

                    result = this.storageMaster.LoadVehicle(commandArgs.ToArray());

                    break;
                case "SendVehicleTo":

                    string sourceName = commandArgs[0];
                    garageSlot = int.Parse(commandArgs[1]);
                    string destinationName = commandArgs[2];

                    result = this.storageMaster.SendVehicleTo(sourceName, garageSlot, destinationName);

                    break;
                case "UnloadVehicle":

                    storageName = commandArgs[0];
                    garageSlot = int.Parse(commandArgs[1]);

                    result = this.storageMaster.UnloadVehicle(storageName, garageSlot);

                    break;
                case "GetStorageStatus":

                    storageName = commandArgs[0];

                    result = this.storageMaster.GetStorageStatus(storageName);

                    break;
            }

            return result;
        }
    }
}
