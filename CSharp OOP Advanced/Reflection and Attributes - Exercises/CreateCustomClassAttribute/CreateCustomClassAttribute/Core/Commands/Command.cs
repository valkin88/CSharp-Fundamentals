﻿namespace CreateCustomClassAttribute.Core.Commands
{
    using CreateCustomClassAttribute.Attributes;
    using CreateCustomClassAttribute.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public abstract class Command : IExecutable
    {
        private InfoAttribute attribute;

        protected Command(string typeName)
        {
            SetAttribute(typeName);
        }

        private void SetAttribute(string typeName)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes().First(t => t.Name.Contains(typeName));

            this.Attribute = (InfoAttribute)type.GetCustomAttributes(false).First();
        }

        protected InfoAttribute Attribute
        {
            get => this.attribute;
            private set => this.attribute = value;
        }

        public abstract string Execute();
    }
}
