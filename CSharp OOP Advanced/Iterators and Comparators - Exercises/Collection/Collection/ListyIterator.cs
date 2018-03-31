using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerable<T>
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

    public void PrintAll()
    {
        if (this.ListOfItems.Count == 0)
        {
            throw new Exception("Invalid Operation!");
        }
        Console.WriteLine(string.Join(" ", this.listOfItems));
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.listOfItems.Count; i++)
        {
            yield return this.listOfItems[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
