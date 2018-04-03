namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var type = typeof(HarvestingFields);
            FieldInfo[] fieldsNeeded = null;
            var input = Console.ReadLine();
            
            while (input != "HARVEST")
            {
                var modificator = input;

                switch (modificator)
                {
                    case "private":
                        fieldsNeeded = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(f => f.IsPrivate).ToArray();
                        PrintFields(fieldsNeeded);
                        break;
                    case "protected":
                        fieldsNeeded = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(f => f.IsFamily).ToArray();
                        PrintFields(fieldsNeeded);
                        break;
                    case "public":
                        fieldsNeeded = type.GetFields();
                        PrintFields(fieldsNeeded);
                        break;
                    case "all":
                        fieldsNeeded = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                        PrintFields(fieldsNeeded);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }
        }

        private static void PrintFields(FieldInfo[] fieldsNeeded)
        {
            string modifier = String.Empty;
            foreach (var field in fieldsNeeded)
            {
                if (field.IsFamily)
                {
                    modifier = "protected";
                }
                else if (field.IsPublic)
                {
                    modifier = "public";
                }
                else
                {
                    modifier = "private";
                }

                Console.WriteLine($"{modifier} {field.FieldType.Name} {field.Name}");
            }
        }
    }
}
