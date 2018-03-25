namespace Logger.Models.Contracts.LogFileContracts
{
    public interface IWriteable
    {
        void WriteToFile(string errorLog);
    }
}
