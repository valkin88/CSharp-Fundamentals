namespace DependencyInversion.Contracts
{
    public interface ICalculator
    {
        void ChangeStrategy(ICalculationStrategy strategy);

        int PerformCalculation(int firstOperand, int secondOperand);
    }
}