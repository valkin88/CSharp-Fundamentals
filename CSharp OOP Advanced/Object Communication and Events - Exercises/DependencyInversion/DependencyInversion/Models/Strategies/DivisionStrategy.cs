namespace DependencyInversion.Models.Strategies
{
    using DependencyInversion.Attributes;
    using DependencyInversion.Contracts;

    [Strategy("/")]
    public class DivisionStrategy : ICalculationStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand / secondOperand;
        }
    }
}