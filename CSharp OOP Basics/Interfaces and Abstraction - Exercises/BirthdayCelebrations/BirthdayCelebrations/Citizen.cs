public class Citizen : IBirthDate
{
    private string name;
    private string birthDate;

    public Citizen(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public virtual string BirthDate
    {
        get { return birthDate; }
        set { birthDate = value; }
    }

    public override string ToString()
    {
        return $"{this.BirthDate}";
    }
}
