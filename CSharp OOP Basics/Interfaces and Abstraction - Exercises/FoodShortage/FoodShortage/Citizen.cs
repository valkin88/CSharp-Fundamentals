public class Citizen : IBuyer
{
    private string name;
    private int age;
    private string id;
    private string birthDate;

    public Citizen(string name, int age, string id, string birthDate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.BirthDate = birthDate;
        this.Food = 0;
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public int Age
    {
        get { return age; }
        private set { age = value; }
    }

    public string Id
    {
        get { return id; }
        private set { id = value; }
    }

    public virtual string BirthDate
    {
        get { return birthDate; }
        private set { birthDate = value; }
    }

    public int Food { get; set; }

    public int BuyFood()
    {
        this.Food += 10;
        return this.Food;
    }

    public override string ToString()
    {
        return $"{this.BirthDate}";
    }
}
