using System;

public class Rebel : IBuyer
{
    private string name;
    private int age;
    private string group;

    public Rebel(string name, int age, string group)
    {
        this.Name = name;
        this.Age = age;
        this.Group = group;
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

    public string Group
    {
        get { return group; }
        private set { group = value; }
    }

    public int Food { get; set; }

    public int BuyFood()
    {
        this.Food += 5;
        return this.Food;
    }

}
