namespace DependencyInversion.Models
{
    using DependencyInversion.Contracts;

    public class Calculator : ICalculator
    {
        private ICalculationStrategy strategy;

        public Calculator(ICalculationStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void ChangeStrategy(ICalculationStrategy strategy)
        {
            this.strategy = strategy;
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            int result = this.strategy.Calculate(firstOperand, secondOperand);

            return result;
        }
    }
}