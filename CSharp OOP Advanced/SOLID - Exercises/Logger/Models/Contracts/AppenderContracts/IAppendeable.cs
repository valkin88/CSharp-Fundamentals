namespace Logger.Models.Contracts.AppenderContracts
{
    public interface IAppendeable
    {
        void Append(IError error);
    }
}
