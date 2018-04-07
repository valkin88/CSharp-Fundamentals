﻿namespace CreateCustomClassAttribute
{
    using CreateCustomClassAttribute.Attributes;
    using CreateCustomClassAttribute.Core;

    [Info("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public class StartUp
    {
        private static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
