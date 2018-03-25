using Logger.Models.Contracts.LogFileContracts;

namespace Logger.Models.Contracts
{
    public interface ILogFile : IPathable, ISizeable, IWriteable
    {

    }
}
