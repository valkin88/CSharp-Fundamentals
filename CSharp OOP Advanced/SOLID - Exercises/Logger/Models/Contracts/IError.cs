using Logger.Models.Contracts.ErrorContracts;

namespace Logger.Models.Contracts
{
    public interface IError : IDateable, IMessageable, ILevelable
    {

    }
}