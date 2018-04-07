namespace InfernoInfinity.Core.Commands
{
    using InfernoInfinity.Contracts;

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

        public abstract void Execute();
    }
}
