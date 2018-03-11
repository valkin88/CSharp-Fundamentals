using System;
using System.Collections.Generic;

public class Child:Person
{
    public Child(string name, int age) : base(name, age)
    {
    }

    public override string Name
    {
        get
        {
            return base.Name;
        }
        set
        {
            base.Name = value;
        }
    }

    public override int Age
    {
        get
        {
            return base.Age;
        }
        set
        {
            if (value > 15)
            {
                throw new ArgumentException("Child's age must be less than 15!");
            }
            base.Age = value;
        }
    }
}
