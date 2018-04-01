using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Person : IComparable<Person>
{
    private string name;
    private int age;
    private string town;

    public Person(string name, int age, string town)
    {
        this.Name = name;
        this.Age = age;
        this.Town = town;
    }

    public string Town
    {
        get { return town; }
        set { town = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int CompareTo(Person person)
    {
        int result = -1;

        if (this.Name == person.Name)
        {
            if (this.Age == person.Age)
            {
                if (this.Town == person.Town)
                {
                    result = 0;
                }
            }
        }
        
        return result;
    }
}
