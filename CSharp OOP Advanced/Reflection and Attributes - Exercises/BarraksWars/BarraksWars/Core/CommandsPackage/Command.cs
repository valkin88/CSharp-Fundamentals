using BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarraksWars.Core.CommandsPackage
{
    public abstract class Command : IExecutable
    {
        private string[] data;

        public Command(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data
        {
            get { return data; }
            private set { data = value; }
        }

        public abstract string Execute();
    }
}
