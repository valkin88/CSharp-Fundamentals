namespace InfernoInfinity
{
    using InfernoInfinity.Contracts;
    using InfernoInfinity.Core;

    class StartUp
    {
        static void Main(string[] args)
        {
            IRunnable engine = new Engine();
            engine.Run();
        }
    }
}
