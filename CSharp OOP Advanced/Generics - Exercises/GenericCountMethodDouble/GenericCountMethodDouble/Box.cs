using System;
using System.Collections;
using System.Collections.Generic;

public class Box<T> where T : IComparable<T>
{
    private T value;
    private List<T> values;

    public Box()
    {
        this.values = new List<T>();
    }

    public T Value
    {
        get { return this.value; }
        set { this.value = value; }
    }

    public void Add(T value) => this.values.Add(value);

    public int CompareTo(T item)
    {
        int countOfBiggerValues = 0;

        foreach (var currentValue in this.values)
        {
            var comparison = item.CompareTo(currentValue);

            if (comparison < 0)
            {
                countOfBiggerValues++;
            }
        }

        return countOfBiggerValues;
    }
}
