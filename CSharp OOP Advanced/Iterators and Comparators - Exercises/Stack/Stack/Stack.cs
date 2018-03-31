using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Stack<T> : IEnumerable<T>
{
    private IList<T> stackOfElements;

    public Stack()
    {
        this.StackOfElements = new List<T>();
    }

    public IList<T> StackOfElements
    {
        get { return stackOfElements; }
        set { stackOfElements = value; }
    }

    public void Push(T[] arrayOfElements)
    {
        for (int i = 0; i < arrayOfElements.Length; i++)
        {
            this.StackOfElements.Add(arrayOfElements[i]);
        }
    }

    public T Pop()
    {
        if (this.StackOfElements.Count == 0)
        {
            throw new Exception("No elements");
        }

        int lastIndex = this.StackOfElements.Count - 1;
        T element = this.StackOfElements[lastIndex];
        this.StackOfElements.Remove(element);

        return element;
    }

    public override string ToString()
    {
        IList<T> copyOfStack = this.StackOfElements.Reverse().ToList();
        string result = string.Join(Environment.NewLine, copyOfStack) + 
                        Environment.NewLine +
                        string.Join(Environment.NewLine, copyOfStack);

        return result;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.StackOfElements.Count; i++)
        {
            yield return this.StackOfElements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
