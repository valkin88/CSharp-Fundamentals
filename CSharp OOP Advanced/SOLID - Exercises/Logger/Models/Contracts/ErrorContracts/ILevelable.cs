using Logger.Enums;

namespace Logger.Models.Contracts.ErrorContracts
{
    public interface ILevelable
    {
        ErrorLevel ErrorLevel { get; }
    }
}
