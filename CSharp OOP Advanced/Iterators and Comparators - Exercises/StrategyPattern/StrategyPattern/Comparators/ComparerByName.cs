using System;
using System.Collections.Generic;
using System.Text;

public class ComparerByName : IComparer<Person>
{
    public int Compare(Person firstPerson, Person secondPerson)
    {
        if (firstPerson.Name.Length == secondPerson.Name.Length)
        {
            if (firstPerson.Name[0].ToString().ToLower().CompareTo(secondPerson.Name[0].ToString().ToLower()) < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        else if (firstPerson.Name.Length < secondPerson.Name.Length)
        {
            return -1;
        }

        return 1;
    }
}
