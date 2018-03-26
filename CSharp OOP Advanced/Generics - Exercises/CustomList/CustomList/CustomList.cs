using System;
using System.Collections.Generic;

public class CustomList<T> where T : IComparable<T>
{
    private List<T> customList;

    public CustomList()
    {
        this.customList = new List<T>();
    }

    public void Add(T element) => this.customList.Add(element);

    public T Remove(int index)
    {
        if (!IndexOutOfRange(index))
        {
            T element = this.customList[index];
            this.customList.RemoveAt(index);
            return element;
        }

        return default(T);
    }

    public bool Contains(T element)
    {
        if (this.customList.Contains(element))
        {
            return true;
        }

        return false;
    }

    public void Swap(int index1, int index2)
    {
        if (!IndexOutOfRange(index1) &&
           !IndexOutOfRange(index2))
        {
            T firstValue = this.customList[index1];
            T secondValue = this.customList[index2];
            this.customList[index1] = secondValue;
            this.customList[index2] = firstValue;
        }
    }

    public int CountGreaterThan(T element)
    {
        if (this.customList.Count == 0)
        {
            return default(int);
        }

        int countOfBiggerValues = 0;

        foreach (var currentValue in this.customList)
        {
            var comparison = element.CompareTo(currentValue);

            if (comparison < 0)
            {
                countOfBiggerValues++;
            }
        }

        return countOfBiggerValues;
    }

    public T Max()
    {
        if (this.customList.Count == 0)
        {
            return default(T);
        }

        T maxValue = this.customList[0];

        if (this.customList.Count == 1)
        {
            return maxValue;
        }
        

        for (int index = 1; index < this.customList.Count; index++)
        {
            T currentValue = this.customList[index];
            var comparison = maxValue.CompareTo(currentValue);

            if (comparison < 0)
            {
                maxValue = currentValue;
            }
        }

        return maxValue;
    }

    public T Min()
    {
        if (this.customList.Count == 0)
        {
            return default(T);
        }

        T minValue = this.customList[0];

        if (this.customList.Count == 1)
        {
            return minValue;
        }


        for (int index = 1; index < this.customList.Count; index++)
        {
            T currentValue = this.customList[index];
            var comparison = minValue.CompareTo(currentValue);

            if (comparison > 0)
            {
                minValue = currentValue;
            }
        }

        return minValue;
    }

    public override string ToString()
    {
        return String.Join(Environment.NewLine, this.customList);
    }

    private bool IndexOutOfRange(int index)
    {
        return index < 0 || index >= this.customList.Count;
    }
}
