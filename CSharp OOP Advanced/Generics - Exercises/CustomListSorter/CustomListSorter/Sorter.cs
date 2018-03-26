using System;
using System.Collections.Generic;
using System.Linq;

public class Sorter<T> where T : IComparable<T>
{
    public List<T> Sort(List<T> customList) 
    {
        int firstIndex = 0;
        int lastIndex = customList.ToArray().Length - 1;
        T[] currentArray = customList.ToArray();

        MergeSort(currentArray, firstIndex, lastIndex);

        return currentArray.ToList();
    }

    private void MergeSort(T[] currentArray, int firstIndex, int lastIndex)
    {
        int middleIndex;

        if (lastIndex > firstIndex)
        {
            middleIndex = (lastIndex + firstIndex) / 2;

            MergeSort(currentArray, firstIndex, middleIndex);

            MergeSort(currentArray, (middleIndex + 1), lastIndex);

            MainMerge(currentArray, firstIndex, middleIndex, lastIndex);
        }
    }

    private void MainMerge(T[] currentArray, int firstIndex, int middleIndex, int lastIndex)
    {
        int rightIndex, leftIndex;

        rightIndex = (middleIndex + 1);
        leftIndex = firstIndex;
        
        T[] copyList = new T[(lastIndex - firstIndex) + 1];
        int tmpIndex = 0;

        while ((leftIndex <= middleIndex) && (rightIndex <= lastIndex))
        {
            var comparator = currentArray[leftIndex].CompareTo(currentArray[rightIndex]);
            if (comparator < 0)
            {
                copyList[tmpIndex] = currentArray[leftIndex];
                leftIndex = leftIndex + 1;
            }
            else
            {
                copyList[tmpIndex] = currentArray[rightIndex];
                rightIndex = rightIndex + 1;
            }
            tmpIndex = tmpIndex + 1;
        }

        if (leftIndex <= middleIndex)
        {
            while (leftIndex <= middleIndex)
            {
                copyList[tmpIndex] = currentArray[leftIndex];
                leftIndex = leftIndex + 1;
                tmpIndex = tmpIndex + 1;
            }
        }

        if (rightIndex <= lastIndex)
        {
            while (rightIndex <= lastIndex)
            {
                copyList[tmpIndex] = currentArray[rightIndex];
                rightIndex = rightIndex + 1;
                tmpIndex = tmpIndex + 1;
            }
        }

        for (int i = 0; i < copyList.Length; i++)
        {
            currentArray[firstIndex + i] = copyList[i];
        }
    }
}
