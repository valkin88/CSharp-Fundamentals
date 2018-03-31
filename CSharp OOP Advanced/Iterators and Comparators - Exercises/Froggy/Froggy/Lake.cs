using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Lake : IEnumerable<int>
{
    private List<int> listOfStones;

    public Lake(List<int> arrayOfStones)
    {
        this.listOfStones = arrayOfStones;
    }

    public IEnumerator<int> GetEnumerator()
    {

        for (int index = 1; index <= this.listOfStones.Count; index++)
        {
            if (index % 2 != 0)
                yield return this.listOfStones[index - 1];
        }

        for (int index = this.listOfStones.Count; index >= 1; index--)
        {
            if (index % 2 == 0)
                yield return this.listOfStones[index - 1];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
