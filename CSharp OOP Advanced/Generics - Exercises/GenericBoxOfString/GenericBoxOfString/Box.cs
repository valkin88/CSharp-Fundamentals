using System;

public class Box<T>
{
    private T value;

    public Box(T value)
    {
        this.Value = value;
    }

    public T Value
    {
        get { return this.value; }
        set { this.value = value; }
    }

    public override string ToString()
    {
        string result = $"{this.Value.GetType().FullName}: {this.Value}";

        return result;
    }
}
