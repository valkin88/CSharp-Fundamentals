namespace Logger.Models.Contracts.AppenderContracts
{
    public interface ILayoutable
    {
        ILayout Layout { get; }
    }
}
