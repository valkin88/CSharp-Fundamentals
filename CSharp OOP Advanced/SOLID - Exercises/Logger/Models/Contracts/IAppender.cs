using Logger.Enums;
using Logger.Models.Contracts.AppenderContracts;
using Logger.Models.Contracts.ErrorContracts;

namespace Logger.Models.Contracts
{
    public interface IAppender : ILevelable, IAppendeable, ILayoutable
    {

    }
}
