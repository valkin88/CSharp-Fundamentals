using System;
using System.Collections.Generic;
using System.Text;

public class ComparerByAge : IComparer<Person>
{
    public int Compare(Person firstPerson, Person secondPerson)
    {
        if (firstPerson.Age < secondPerson.Age)
        {
            return -1;
        }
        else if (firstPerson.Age > secondPerson.Age)
        {
            return 1;
        }

        return 0;
    }
}
