public class Person : Citizen, IBirthDate
{
    private int age;
    private string id;

    public override string BirthDate { get => base.BirthDate; set => base.BirthDate = value; }

    public Person(string name, int age, string id, string birthDate)
        :base(name)
    {
        this.Age = age;
        this.Id = id;
        this.BirthDate = birthDate;
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
}
