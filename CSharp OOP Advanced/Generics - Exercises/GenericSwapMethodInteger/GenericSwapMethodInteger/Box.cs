using System;
using System.Collections;
using System.Collections.Generic;

public class Box<T> : IEnumerable<T>
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

    public void Swap(int firstIndex, int secondIndex)
    {
        T firstValue = this.values[firstIndex];
        T secondValue = this.values[secondIndex];
        this.values[firstIndex] = secondValue;
        this.values[secondIndex] = firstValue;
    }

    public void Add(T value) => this.values.Add(value);

    public IEnumerator<T> GetEnumerator()
    {
        return this.values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.values.GetEnumerator();
    }
}
