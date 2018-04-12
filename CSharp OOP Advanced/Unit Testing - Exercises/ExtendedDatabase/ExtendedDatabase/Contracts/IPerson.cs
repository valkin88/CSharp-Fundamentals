namespace ExtendedDatabase.Contracts
{
    public interface IPerson : IIdentifiable
    {
        string Username { get; }
    }
}
