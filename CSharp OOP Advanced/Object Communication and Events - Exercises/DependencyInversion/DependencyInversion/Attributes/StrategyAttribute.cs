namespace DependencyInversion.Attributes
{
    using System;

    public class StrategyAttribute : Attribute
    {
        public StrategyAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}