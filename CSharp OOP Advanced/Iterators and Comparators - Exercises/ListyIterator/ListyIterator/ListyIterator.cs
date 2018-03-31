using System;
using System.Collections.Generic;

public class ListyIterator<T>
{
    private IList<T> listOfItems;
    private int currentIndex;
    public ListyIterator(T[] listOfItems)
    {
        this.ListOfItems = listOfItems;
        currentIndex = 0;
    }

    public IList<T> ListOfItems
    {
        get { return listOfItems; }
        set
        {
            listOfItems = value;
        }
    }

    public bool Move()
    {
        if (currentIndex + 1 <= this.ListOfItems.Count - 1)
        {
            currentIndex++;
            Console.WriteLine("True");
            return true;
        }
        Console.WriteLine("False");
        return false;
    }

    public void Print()
    {
        if (this.ListOfItems.Count == 0)
        {
            throw new Exception("Invalid Operation!");
        }
        Console.WriteLine($"{this.ListOfItems[currentIndex]}");
    }

    public bool HasNext()
    {
        if (currentIndex + 1 <= this.ListOfItems.Count - 1)
        {
            Console.WriteLine("True");
            return true;
        }
        Console.WriteLine("False");
        return false;
    }
}
